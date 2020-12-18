using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Database;
using Wallet.Database.Models;
using Wallet.Database.Models.Operations;
using Wallet.ViewModels;

namespace Wallet.Services.OperationServices
{
    public abstract class OperationServiceBase<TRequest> : IOperationService<TRequest> where TRequest : OperationDto
    {
        protected readonly WalletContext Context;
        protected readonly CommissionManager CommissionManager;
        public OperationType Type { get; }

        protected OperationServiceBase(WalletContext context, CommissionManager commissionManager, OperationType type)
        {
            Context = context;
            Type = type;
            CommissionManager = commissionManager;
        }

        public async Task<bool> TryDoOperationAsync(string userId, TRequest request)
        {
            var currencyId = (await Context.Currencies.FirstOrDefaultAsync(c => c.Name == request.CurrencyName)).Id;
            var accountId =
                (await Context.Accounts.FirstOrDefaultAsync(a => a.Name == request.AccountName && a.UserId == userId))
                .Id;
            var commission = await CommissionManager.CalculateCommissionAsync(userId, currencyId,
                Type, request.Value);
            var wallet = await GetOrCreateWalletAsync(currencyId, accountId);

            var operation = await CreateOperationAsync(request, currencyId, commission, accountId, wallet);
            
            if (operation.Commission >= operation.Value)
                return false;
            if (!CheckWalletValue(wallet, operation))
                return false;

            await Context.Operations.AddAsync(operation);
            await Context.SaveChangesAsync();

            var maxOperationValue =
                await CommissionManager.GetMaximalOperationValueAsync(userId, currencyId, OperationType.Deposit);

            if (maxOperationValue != 0 && maxOperationValue < operation.Value)
                return true;

            return await TryConfirmOperationAsync(operation.Id);
        }

        public abstract Task<bool> TryConfirmOperationAsync(int operationId);

        protected abstract Task<OperationRecord> CreateOperationAsync(TRequest request, int currencyId,
            double commission, int accountId, WalletRecord wallet);

        protected abstract bool CheckWalletValue(WalletRecord wallet, OperationRecord operation);

        protected async Task<WalletRecord> GetOrCreateWalletAsync(int currencyId, int accountId)
        {
            var wallet = await Context.Wallets
                .FirstOrDefaultAsync(w => w.CurrencyId == currencyId && w.AccountId == accountId);
            if (wallet != null)
                return wallet;
            wallet = new WalletRecord {AccountId = accountId, CurrencyId = currencyId};
            await Context.Wallets.AddAsync(wallet);
            await Context.SaveChangesAsync();
            return wallet;
        }

        protected async Task<OperationRecord> GetOperationAsync(int operationId) =>
            await Context.Operations.FirstOrDefaultAsync(o => o.Id == operationId);
    }
}