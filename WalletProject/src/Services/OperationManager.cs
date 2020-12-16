using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Database;
using Wallet.Database.Models;
using Wallet.Database.Models.Operations;
using Wallet.Helpers;
using Wallet.Models.Commissions;

namespace Wallet.Services
{
    public class OperationManager
    {
        private readonly ICommissionRecordReader<ICommission>[] _commissionRecordReaders;
        private readonly WalletContext _context;

        public OperationManager(AbsoluteCommissionRecordReader absoluteCommissionRecordReader,
            RelativeCommissionRecordReader relativeCommissionRecordReader,
            WalletContext context)
        {
            _commissionRecordReaders = new ICommissionRecordReader<ICommission>[]
                {absoluteCommissionRecordReader, relativeCommissionRecordReader};
            _context = context;
        }

        public async Task<bool> TryWithdraw(string currencyId, string accountId, double value)
        {
            var wallet = await _context.Wallets
                             .FirstOrDefaultAsync(w =>
                                 w.CurrencyId == currencyId && w.AccountId == accountId) ??
                         await CreateWallet(currencyId, accountId);
            var commission = await GetCommission(currencyId, wallet.Account.Id, OperationType.Withdrawal);
            var commissionValue = commission.Calculate(value);
            if (commissionValue + value > wallet.Value)
                return false;
            if (commission.MaxOperationValue != 0 && value > commission.MaxOperationValue)
                await _context.Operations.AddAsync(new OperationRecord
                {
                    Id = Guid.NewGuid().ToString(), Wallet = wallet, Type = OperationType.Withdrawal,
                    Value = value, Commission = commissionValue
                });
            else
                wallet.Value -= commissionValue + value;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TryDeposit(string currencyId, string accountId, double value)
        {
            var wallet = await _context.Wallets
                             .FirstOrDefaultAsync(w =>
                                 w.CurrencyId == currencyId && w.AccountId == accountId) ??
                         await CreateWallet(currencyId, accountId);
            var commission = await GetCommission(currencyId, wallet.Account.Id, OperationType.Deposit);
            var commissionValue = commission.Calculate(value);
            if (value - commissionValue < 0)
                return false;
            if (commission.MaxOperationValue != 0 && value > commission.MaxOperationValue)
                await _context.Operations.AddAsync(new OperationRecord
                {
                    Id = Guid.NewGuid().ToString(), TargetWallet = wallet, Type = OperationType.Deposit,
                    Value = value, Commission = commissionValue
                });
            else
                wallet.Value += value - commissionValue;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TryTransfer(string currencyId, string accountId, string targetAccountId, double value)
        {
            var wallet = await _context.Wallets
                .FirstOrDefaultAsync(w =>
                    w.CurrencyId == currencyId && w.AccountId == accountId);
            if (wallet == null)
                return false;
            var targetWallet = await _context.Wallets
                                   .FirstOrDefaultAsync(w =>
                                       w.CurrencyId == currencyId && w.AccountId == targetAccountId) ??
                               await CreateWallet(currencyId, accountId);
            var commission = await GetCommission(currencyId, accountId, OperationType.Transfer);
            var commissionValue = commission.Calculate(value);
            if (commissionValue + value > wallet.Value)
                return false;
            if (commission.MaxOperationValue != 0 && value > commission.MaxOperationValue)
                await _context.Operations.AddAsync(new OperationRecord
                {
                    Id = Guid.NewGuid().ToString(), Wallet = wallet, TargetWallet = targetWallet,
                    Type = OperationType.Transfer, Value = value, Commission = commissionValue
                });
            else
            {
                wallet.Value -= commissionValue + value;
                targetWallet.Value += value;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<ICommission> GetCommission(string currencyId, string userId, OperationType type)
        {
            var commissionRecord = await _context.Commissions
                                       .FirstOrDefaultAsync(c =>
                                           c.UserId != null && c.UserId == userId &&
                                           c.CurrencyId == currencyId &&
                                           c.OperationType == type)
                                   ?? await _context.Commissions.FirstOrDefaultAsync(c =>
                                       c.CurrencyId == currencyId && c.OperationType == type);
            if (commissionRecord == null)
                throw new Exception("Object not found");

            var commission = _commissionRecordReaders
                .FirstOrDefault(c => c.CommissionType == commissionRecord.Type)?
                .ReadFromRecord(commissionRecord);
            if (commission != null) return commission;

            throw new Exception("Object not found");
        }

        private async Task<WalletRecord> CreateWallet(string currencyId, string accountId)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.Id == accountId);
            account.Wallets = new List<WalletRecord>
            {
                new WalletRecord
                    {CurrencyId = currencyId, Id = Guid.NewGuid().ToString(), Account = account}
            };
            await _context.SaveChangesAsync();
            return account.Wallets[0];
        }

        public async Task ConfirmOperation(string operationId)
        {
            var operationRecord = await _context.Operations.FirstOrDefaultAsync(o => o.Id == operationId);
            if (operationRecord == null)
                return;
            var operation = operationRecord.ToOperation();
            if (await operation.TryDoOperation(_context))
                _context.Operations.Remove(operationRecord);
        }
    }
}