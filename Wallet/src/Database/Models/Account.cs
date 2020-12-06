using System.Collections.Generic;

namespace Wallet
{
    public class Account
    {
        public int AccountId { get; set; }
        public string Name { get; set; }

        public User User { get; set; }
        public List<Wallet> Wallets { get; set; }
    }
}