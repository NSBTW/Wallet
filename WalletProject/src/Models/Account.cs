using System.Collections.Generic;
using Wallet.Database.Models;

namespace Wallet.Models
{
    public class Account
    {
        private readonly int _id;
        public string Name { get; }
        private readonly List<Wallet> _wallets;

        public Account(int id, string name)
        {
            _id = id;
            Name = name;
            _wallets = new List<Wallet>();
        }

        public Account(int id, string name, List<Wallet> wallets) : this(id, name)
        {
            _wallets = wallets;
        }

        public AccountRecord ToRecord(string userId) => new AccountRecord
            {Id = _id, Name = Name, UserId = userId};

        public IEnumerable<Wallet> GetWallets() => _wallets;
    }
}