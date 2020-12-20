using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Database;
using Wallet.Database.Models;
using Wallet.Database.Models.Operations;
using Wallet.ViewModels;

namespace Wallet.Services.OperationServices
{
    public class TransferOperationService : OperationServiceBase<TransferOperationDto>
    {
        public TransferOperationService(WalletContext context, CommissionManager commissionManager)
            : base(context, commissionManager, OperationType.Transfer)
        {
        }

        protected override async Task<OperationRecord> CreateOperationAsync(TransferOperationDto dto,
            int currencyId, double commission, int accountId, WalletRecord wallet)
        {
            var userId = (await Context.Users.FirstOrDefaultAsync(u => u.UserName == dto.UserName)).Id;
            var toAccountId =
                (await Context.Accounts.FirstOrDefaultAsync(a => a.Name == dto.ToAccountName && a.UserId == userId))
                .Id;
            var toWallet = await GetOrCreateWalletAsync(currencyId, toAccountId);
            return new OperationRecord
            {
                WalletId = wallet.Id, Type = Type, Value = dto.Value,
                Commission = commission, TransferWalletId = toWallet.Id
            };
        }

        protected override bool CheckWalletValue(WalletRecord wallet, OperationRecord operation) =>
            wallet.Value > operation.Value + operation.Commission;

        public override async Task<bool> TryConfirmOperationAsync(int operationId)
        {
            var operation = await Context.Operations
                .Where(o => o.Id == operationId)
                .Include(o => o.Wallet)
                .Include(o => o.TransferWallet)
                .FirstOrDefaultAsync();
            if (!CheckWalletValue(operation.Wallet, operation))
                return false;
            operation.Wallet.Value -= operation.Value + operation.Commission;
            operation.TransferWallet.Value += operation.Value;
            operation.IsCompleted = true;
            await Context.SaveChangesAsync();
            return true;
        }
    }
}