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
        public string Name { get; private set; }

        public Account(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public AccountRecord ToRecord() => new AccountRecord
            {Id = Id, Name = Name};

        public async Task<List<Wallet>> Wallets(WalletContext context) =>
            await context.Wallets
                .Where(w => w.AccountId == Id)
                .Include(w => w.Currency)
                .Select(w => w.ToWallet())
                .ToListAsync();

    }
}