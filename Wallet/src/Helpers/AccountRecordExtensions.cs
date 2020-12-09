using Wallet.Database;
using Wallet.Database.Models;
using Wallet.Models;

namespace Wallet.Helpers
{
    public static class AccountRecordExtensions
    {
        public static Account ToAccount(this AccountRecord record, string userId, WalletDbContext context) =>
            new Account(record.Id, record.Name, context, userId);
    }
}