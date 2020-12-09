using System.Collections.Generic;

namespace Wallet.Database.Models
{
    public class AccountRecord
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public UserRecord UserRecord { get; set; }
        public List<WalletRecord> Wallets { get; set; }
    }
}