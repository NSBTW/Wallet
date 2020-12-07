using System.Collections.Generic;

namespace Wallet.Database.Models
{
    public class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public User User { get; set; }
        public List<Database.Models.Wallet> Wallets { get; set; }
    }
}