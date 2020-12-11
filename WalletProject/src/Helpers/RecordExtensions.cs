using System;
using System.Diagnostics;
using Wallet.Database.Models;
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
            new Models.Wallet(record.Id, record.Value, record.CurrencyRecord.Name);

        public static IOperation ToOperation(this OperationRecord record) => record.Type switch
        {
            OperationType.Deposit => new DepositOperation(record.Value, record.Commission, record.TargetWalletRecordId),
            OperationType.Transfer => new TransferOperation(record.Value, record.Commission, record.WalletRecordId,
                record.TargetWalletRecordId),
            OperationType.Withdrawal => new WithdrawOperation(record.Value, record.Commission, record.WalletRecordId),
            _ => null
        };
    }
}