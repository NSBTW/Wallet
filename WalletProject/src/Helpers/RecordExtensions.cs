using System;
using System.Diagnostics;
using Wallet.Database.Models;
using Wallet.Database.Models.Commissions;
using Wallet.Database.Models.Operations;
using Wallet.Models;
using Wallet.Models.Operations;

namespace Wallet.Helpers
{
    public static class RecordExtensions
    {
        public static Account ToAccount(this AccountRecord record) =>
            new Account(record.Id, record.Name);

        public static Models.Wallet ToWallet(this WalletRecord record) =>
            new Models.Wallet(record.Id, record.Value, record.Currency.Name);

        public static IOperation ToOperation(this OperationRecord record) => record.Type switch
        {
            OperationType.Deposit => new DepositOperation(record.Value, record.Commission, record.TargetWalletId),
            OperationType.Transfer => new TransferOperation(record.Value, record.Commission, record.WalletId,
                record.TargetWalletId),
            OperationType.Withdrawal => new WithdrawOperation(record.Value, record.Commission, record.WalletId),
            _ => null
        };

        public static CommissionRecord CreateSameCommission(this CommissionRecord commission, OperationType type) =>
            new CommissionRecord
            {
                Id = Guid.NewGuid().ToString(), Rate = commission.Rate, Type = commission.Type, OperationType = type,
                Value = commission.Value, CurrencyId = commission.CurrencyId, MaxCommission = commission.MaxCommission,
                MaxValue = commission.MaxValue, MinCommission = commission.MinCommission, UserId = commission.UserId
            };
    }
}