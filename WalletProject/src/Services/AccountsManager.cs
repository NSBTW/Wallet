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
                .Select(a => new Account(a.Id, a.Name))
                .ToListAsync();

        public async Task<bool> TryAddAccountAsync(UserRecord record, string accountName)
        {
            if (await _walletContext.Accounts.FirstOrDefaultAsync(a =>
                a.UserId == record.Id && a.Name == accountName) != null)
                return false;
            record.Accounts = new List<AccountRecord> {new Account(Guid.NewGuid().ToString(), accountName).ToRecord()};
            await _userManager.UpdateAsync(record);
            return true;
        }

        public async Task<Account> GetAccount(string userId, string accountName) =>
            (await _walletContext.Accounts.FirstOrDefaultAsync(a =>
                a.UserId == userId && a.Name == accountName))?.ToAccount();

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