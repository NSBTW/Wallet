using System.Collections.Generic;

namespace Wallet.Database.Models
{
    public class AccountRecord
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string UserId { get; set; }


        public UserRecord User { get; set; }
        public List<WalletRecord> Wallets { get; set; }
    }
}