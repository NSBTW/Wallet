using Wallet.Database.Models;
using Wallet.Models;

namespace Wallet.Helpers
{
    public static class RecordExtensions
    {
        public static Account ToAccount(this AccountRecord record) =>
            new Account(record.Id, record.Name);

        public static Models.Wallet ToWallet(this WalletRecord record) => 
            new Models.Wallet(record.Id, record.Value, record.CurrencyRecord.Name);
    }
}