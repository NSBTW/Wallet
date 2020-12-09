using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Wallet.Database;
using Wallet.Database.Models;
using Wallet.Helpers;
using Wallet.Models;

namespace Wallet.Services
{
    public class AccountsManager
    {
        private readonly WalletDbContext _walletDbContext;

        public AccountsManager(WalletDbContext walletDbContext)
        {
            _walletDbContext = walletDbContext;
        }

        public async Task<List<Account>> Accounts(string userId) =>
            await _walletDbContext.Accounts
                .Where(a => a.UserRecord.Id == userId)
                .Select(a => new Account(a.Id, a.Name, _walletDbContext, userId))
                .ToListAsync();

        public async Task<bool> TryAddAccount(string userId, string accountName)
        {
            if (await _walletDbContext.Accounts.FirstOrDefaultAsync(a =>
                a.UserRecord.Id == userId && a.Name == accountName) == null)
                return false;
            await _walletDbContext.Accounts.AddAsync(
                new Account(Guid.NewGuid().ToString(), accountName, _walletDbContext, userId).ToRecord());
            await _walletDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Account> GetAccount(string userId, string accountName) =>
            (await _walletDbContext.Accounts.FirstOrDefaultAsync(a =>
                a.UserRecord.Id == userId && a.Name == accountName))?.ToAccount(userId, _walletDbContext);
    }
}