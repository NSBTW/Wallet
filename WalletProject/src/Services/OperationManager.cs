using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Database;
using Wallet.Database.Models;
using Wallet.Database.Models.Operations;
using Wallet.Helpers;

namespace Wallet.Services
{
    public class OperationManager
    {
        private readonly WalletContext _context;
        private readonly CommissionManager _commissionManager;

        public OperationManager(WalletContext context, CommissionManager commissionManager)
        {
            _context = context;
            _commissionManager = commissionManager;
        }

        public async Task<bool> TryDoOperation(string currencyId, string accountId,
            double value, OperationType type, string targetAccountId = null)
        {
            if (type == OperationType.Transfer)
                if (targetAccountId == null)
                    throw new ArgumentException();

            var userId = (await _context.Accounts.FirstOrDefaultAsync(a => a.Id == accountId)).UserId;
            var commission =
                await _commissionManager.CalculateCommission(userId, currencyId, OperationType.Withdrawal, value);

            var wallet = await GetWalletAsync(currencyId, accountId);
            if (!IsOperationValid(value, commission, wallet?.Value ?? 0, type))
                return false;
            wallet ??= await CreateWalletAsync(currencyId, accountId);
            
            var targetWallet = type == OperationType.Transfer
                ? await GetWalletAsync(currencyId, targetAccountId) ??
                  await CreateWalletAsync(currencyId, targetAccountId)
                : null;

            var maxOperationValue = await _commissionManager.GetMaximalOperationValue(userId, currencyId, type);
            var record = new OperationRecord
            {
                Id = Guid.NewGuid().ToString(), WalletId = wallet.Id, Type = type, Value = value,
                Commission = commission, TransferWalletId = targetWallet?.Id
            };
            if (maxOperationValue != 0 && value > maxOperationValue)
                await _context.Operations.AddAsync(record);
            else
                return await record.ToOperation().TryDoOperationAsync(_context);
            return true;
        }

        public bool IsOperationValid(double value, double commission, double walletValue, OperationType type) =>
            type switch {
                OperationType.Deposit => ,
                OperationType.Transfer => ,
                OperationType.Withdrawal => ,
                _ => 
            };

        public async Task<WalletRecord> GetWalletAsync(string currencyId, string accountId) => await _context.Wallets
            .FirstOrDefaultAsync(w => w.CurrencyId == currencyId && w.AccountId == accountId);

        private async Task<WalletRecord> CreateWalletAsync(string currencyId, string accountId)
        {
            var record = new WalletRecord
                {Id = Guid.NewGuid().ToString(), AccountId = accountId, CurrencyId = currencyId};
            await _context.Wallets.AddAsync(record);
            await _context.SaveChangesAsync();
            return record;
        }

        public async Task ConfirmOperationAsync(string operationId)
        {
            var operationRecord = await _context.Operations.FirstOrDefaultAsync(o => o.Id == operationId);
            if (operationRecord == null)
                return;
            var operation = operationRecord.ToOperation();
            if (await operation.TryDoOperationAsync(_context))
                _context.Operations.Remove(operationRecord);
        }
    }
}