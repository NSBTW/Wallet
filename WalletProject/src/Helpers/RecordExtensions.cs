using System;
using System.Linq;
using Wallet.Database.Models;
using Wallet.Database.Models.Commissions;
using Wallet.Database.Models.Operations;
using Wallet.Models;

namespace Wallet.Helpers
{
    public static class RecordExtensions
    {
        public static Account ToAccount(this AccountRecord record) =>
            new Account(record.Id, record.Name, record.Wallets.Select(w => w.ToWallet()).ToList());

        public static Models.Wallet ToWallet(this WalletRecord record) =>
            new Models.Wallet(record.Id, record.Value, record.Currency.Name);


        public static CommissionRecord CreateSameCommission(this CommissionRecord commission, OperationType type,
            int id) =>
            new CommissionRecord
            {
                Id = id, Rate = commission.Rate, Type = commission.Type, OperationType = type,
                Value = commission.Value, CurrencyId = commission.CurrencyId, MaxCommission = commission.MaxCommission,
                MaxValue = commission.MaxValue, MinCommission = commission.MinCommission, UserId = commission.UserId
            };
    }
}