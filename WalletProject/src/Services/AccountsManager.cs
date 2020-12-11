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
        private readonly UserManager<UserRecord> _userManager;

        public AccountsManager(WalletDbContext walletDbContext, UserManager<UserRecord> userManager)
        {
            _walletDbContext = walletDbContext;
            _userManager = userManager;
        }

        public async Task<List<Account>> Accounts(string userId) =>
            await _walletDbContext.Accounts
                .Where(a => a.UserRecordId == userId)
                .Select(a => new Account(a.Id, a.Name))
                .ToListAsync();

        public async Task<bool> TryAddAccountAsync(UserRecord record, string accountName)
        {
            if (await _walletDbContext.Accounts.FirstOrDefaultAsync(a =>
                a.UserRecordId == record.Id && a.Name == accountName) != null)
                return false;
            record.Accounts = new List<AccountRecord> {new Account(Guid.NewGuid().ToString(), accountName).ToRecord()};
            await _userManager.UpdateAsync(record);
            return true;
        }

        public async Task<Account> GetAccount(string userId, string accountName) =>
            (await _walletDbContext.Accounts.FirstOrDefaultAsync(a =>
                a.UserRecordId == userId && a.Name == accountName))?.ToAccount();

        public async Task<bool> TryChangeAccountValue(string userName, string accountName, string currencyName,
            double value)
        {
            var user = await _userManager.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();
            var account = await GetAccount(user.Id, accountName);
            if (account == null)
                return false;
            var currency = await _walletDbContext.Currencies
                .FirstOrDefaultAsync(c => c.Name == currencyName);

            var wallet = await _walletDbContext.Wallets.FirstOrDefaultAsync(w =>
                w.AccountRecordId == account.Id && w.CurrencyRecordId == currency.Id);
            if (wallet == null)
                wallet = new WalletRecord {CurrencyRecord = currency, Value = value, Id = Guid.NewGuid().ToString()};
            else
                wallet.Value = value;
            await _walletDbContext.SaveChangesAsync();
            return true;
        }
    }
}