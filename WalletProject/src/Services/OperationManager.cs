using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Database;
using Wallet.Database.Models;
using Wallet.Database.Models.Commissions;
using Wallet.Database.Models.Operations;
using Wallet.Helpers;
using Wallet.Models;
using Wallet.Models.Commissions;
using Wallet.ViewModels;

namespace Wallet.Services
{
    public class OperationManager
    {
        private readonly ICommissionRecordReader<ICommission>[] _commissionRecordReaders;
        private readonly WalletDbContext _context;

        public OperationManager(AbsoluteCommissionRecordReader absoluteCommissionRecordReader,
            RelativeCommissionRecordReader relativeCommissionRecordReader,
            WalletDbContext context)
        {
            _commissionRecordReaders = new ICommissionRecordReader<ICommission>[]
                {absoluteCommissionRecordReader, relativeCommissionRecordReader};
            _context = context;
        }

        public async Task<bool> TryWithdraw(string currencyId, string accountId, double value)
        {
            var wallet = await _context.Wallets
                             .FirstOrDefaultAsync(w =>
                                 w.CurrencyRecordId == currencyId && w.AccountRecordId == accountId) ??
                         await CreateWallet(currencyId, accountId);
            var commission =
                await CalculateCommission(currencyId, wallet.AccountRecord.Id, OperationType.Withdrawal, value);
            if (commission + value > wallet.Value)
                return false;
            var currency = await _context.Currencies.FirstOrDefaultAsync(c => c.Id == currencyId);
            if (currency.MaxWithdrawal != 0 && value > currency.MaxDeposit)
                await _context.Operations.AddAsync(new OperationRecord
                {
                    Id = Guid.NewGuid().ToString(), WalletRecord = wallet, Type = OperationType.Withdrawal,
                    Value = value, Commission = commission
                });
            else
                wallet.Value -= commission + value;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TryDeposit(string currencyId, string accountId, double value)
        {
            var wallet = await _context.Wallets
                             .FirstOrDefaultAsync(w =>
                                 w.CurrencyRecordId == currencyId && w.AccountRecordId == accountId) ??
                         await CreateWallet(currencyId, accountId);
            var commission =
                await CalculateCommission(currencyId, wallet.AccountRecord.Id, OperationType.Deposit, value);
            if (value - commission < 0)
                return false;
            var currency = await _context.Currencies.FirstOrDefaultAsync(c => c.Id == currencyId);
            if (currency.MaxDeposit != 0 && value > currency.MaxDeposit)
                await _context.Operations.AddAsync(new OperationRecord
                {
                    Id = Guid.NewGuid().ToString(), TargetWalletRecord = wallet, Type = OperationType.Deposit,
                    Value = value, Commission = commission
                });
            else
                wallet.Value += value - commission;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> TryTransfer(string currencyId, string accountId, string targetAccountId, double value)
        {
            var wallet = await _context.Wallets
                .FirstOrDefaultAsync(w =>
                    w.CurrencyRecordId == currencyId && w.AccountRecordId == accountId);
            if (wallet == null)
                return false;
            var targetWallet = await _context.Wallets
                                   .FirstOrDefaultAsync(w =>
                                       w.CurrencyRecordId == currencyId && w.AccountRecordId == targetAccountId) ??
                               await CreateWallet(currencyId, accountId);
            var commission =
                await CalculateCommission(currencyId, accountId, OperationType.Transfer, value);
            if (commission + value > wallet.Value)
                return false;
            var currency = await _context.Currencies.FirstOrDefaultAsync(c => c.Id == currencyId);
            if (currency.MaxTransfer != 0 && value > currency.MaxDeposit)
                await _context.Operations.AddAsync(new OperationRecord
                {
                    Id = Guid.NewGuid().ToString(), WalletRecord = wallet, TargetWalletRecord = targetWallet,
                    Type = OperationType.Transfer, Value = value, Commission = commission
                });
            else
            {
                wallet.Value -= commission + value;
                targetWallet.Value += value;
            }

            await _context.SaveChangesAsync();
            return true;
        }

        private async Task<double> CalculateCommission(string currencyId, string userId, OperationType type,
            double value)
        {
            var commissionRecord = await _context.Commissions
                                       .FirstOrDefaultAsync(c =>
                                           c.IsUserCommission && c.UserRecordId == userId &&
                                           c.CurrencyRecordId == currencyId &&
                                           c.OperationType == type)
                                   ?? await _context.Commissions.FirstOrDefaultAsync(c =>
                                       c.CurrencyRecordId == currencyId && c.OperationType == type);
            if (commissionRecord == null)
                throw new Exception("Object not found");

            var commission = _commissionRecordReaders
                .FirstOrDefault(c => c.CommissionType == commissionRecord.Type)?
                .ReadFromRecord(commissionRecord);
            if (commission != null) return commission.Calculate(value);

            return 0;
        }

        private async Task<WalletRecord> CreateWallet(string currencyId, string accountId)
        {
            var account = await _context.Accounts
                .FirstOrDefaultAsync(a => a.Id == accountId);
            account.Wallets = new List<WalletRecord>
            {
                new WalletRecord
                    {CurrencyRecordId = currencyId, Id = Guid.NewGuid().ToString(), AccountRecord = account}
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