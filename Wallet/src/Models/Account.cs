using System;
using System.Collections.Generic;
using Wallet.Database;
using Wallet.Database.Models;

namespace Wallet.Models
{
    public class Account
    {
        private readonly string _id;
        private readonly string _userId;
        private readonly WalletDbContext _context;
        public string Name { get; private set; }

        public Account(string id, string name, WalletDbContext context, string userId)
        {
            _id = id;
            _context = context;
            _userId = userId;
            Name = name;
        }

        public AccountRecord ToRecord() => new AccountRecord
            {Id = _id, Name = Name, UserRecord = new UserRecord{Id = _userId}};
    }
}