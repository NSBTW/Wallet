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
    public class WithdrawalOperationService : OperationServiceBase<OperationDto>
    {
        public WithdrawalOperationService(WalletContext context, CommissionManager commissionManager) : base(context,
            commissionManager, OperationType.Withdrawal)
        {
        }

        protected override async Task<OperationRecord> CreateOperationAsync(OperationDto dto,
            int currencyId, double commission, int accountId, WalletRecord wallet)
        {
            var time = DateTime.Now;
            return new OperationRecord
            {
                WalletId = wallet.Id, Type = Type, Value = dto.Value,
                Commission = commission
            };
        }

        protected override bool CheckWalletValue(WalletRecord wallet, OperationRecord operation) =>
            wallet.Value > operation.Value + operation.Commission;

        public override async Task<bool> TryConfirmOperationAsync(int operationId)
        {
            var operation = await Context.Operations
                .Where(o => o.Id == operationId)
                .Include(o => o.Wallet)
                .FirstOrDefaultAsync();
            if (!CheckWalletValue(operation.Wallet, operation))
                return false;
            operation.Wallet.Value -= operation.Value + operation.Commission;
            operation.IsCompleted = true;
            await Context.SaveChangesAsync();
            return true;
        }
    }
}