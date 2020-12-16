using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Wallet.Database;
using Wallet.Database.Models;
using Wallet.Helpers;

namespace Wallet.Models
{
    public class Account
    {
        public readonly string Id;
        public string Name { get; }
        private readonly List<Wallet> _wallets;
        public Account(string id, string name)
        {
            Id = id;
            Name = name;
            _wallets = new List<Wallet>();
        }
        public Account(string id, string name, List<Wallet> wallets) : this(id, name)
        {
            _wallets = wallets;
        }

        public AccountRecord ToRecord(string userId) => new AccountRecord
            {Id = Id, Name = Name, UserId = userId};

        public IEnumerable<Wallet> GetWallets() => _wallets;
    }
}