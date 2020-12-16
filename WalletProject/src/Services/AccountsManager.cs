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
        private readonly WalletContext _walletContext;
        private readonly UserManager<UserRecord> _userManager;

        public AccountsManager(WalletContext walletContext, UserManager<UserRecord> userManager)
        {
            _walletContext = walletContext;
            _userManager = userManager;
        }

        public async Task<List<Account>> Accounts(string userId) =>
            await _walletContext.Accounts
                .Where(a => a.UserId == userId)
                .Include(a => a.Wallets)
                .Select(a => a.ToAccount())
                .ToListAsync();

        public async Task<bool> TryAddAccountAsync(string userId, string accountName)
        {
            if (await _walletContext.Accounts.FirstOrDefaultAsync(a =>
                a.UserId == userId && a.Name == accountName) != null)
                return false;
            await _walletContext.Accounts.AddAsync(
                new Account(Guid.NewGuid().ToString(), accountName).ToRecord(userId));
            await _walletContext.SaveChangesAsync();
            return true;
        }

        public async Task<Account> GetAccount(string userId, string accountName) =>
            (await _walletContext.Accounts
                .Include(a => a.Wallets)
                .FirstOrDefaultAsync(a => a.UserId == userId && a.Name == accountName))?
            .ToAccount();
        
        public async Task<bool> TryChangeAccountValue(string userName, string accountName, string currencyName,
            double value)
        {
            var user = await _userManager.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();
            var account = await GetAccount(user.Id, accountName);
            if (account == null)
                return false;
            var currency = await _walletContext.Currencies
                .FirstOrDefaultAsync(c => c.Name == currencyName);

            var wallet = await _walletContext.Wallets.FirstOrDefaultAsync(w =>
                w.AccountId == account.Id && w.CurrencyId == currency.Id);
            if (wallet == null)
            {
                wallet = new WalletRecord {Currency = currency, Value = value, Id = Guid.NewGuid().ToString()};
                await _walletContext.Wallets.AddAsync(wallet);
            }
            else
                wallet.Value = value;

            await _walletContext.SaveChangesAsync();
            return true;
        }
    }
}