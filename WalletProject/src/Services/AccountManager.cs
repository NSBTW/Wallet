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
    public class AccountManager
    {
        private readonly WalletContext _walletContext;
        private readonly UserManager<UserRecord> _userManager;

        public AccountManager(WalletContext walletContext, UserManager<UserRecord> userManager)
        {
            _walletContext = walletContext;
            _userManager = userManager;
        }

        public async Task<List<Account>> GetAccountsAsync(string userId) =>
            await _walletContext.Accounts
                .Where(a => a.UserId == userId)
                .Include(a => a.Wallets)
                .ThenInclude(w => w.Currency)
                .Select(a => a.ToAccount())
                .ToListAsync();

        public async Task<bool> TryAddAccountAsync(string userId, string accountName)
        {
            if (await _walletContext.Accounts.FirstOrDefaultAsync(a =>
                a.UserId == userId && a.Name == accountName) != null)
                return false;
            await _walletContext.Accounts.AddAsync(
                new AccountRecord{Name = accountName, UserId = userId});
            await _walletContext.SaveChangesAsync();
            return true;
        }

        public async Task<Account> GetAccountAsync(string userId, string accountName) =>
            (await _walletContext.Accounts
                .Include(a => a.Wallets)
                .ThenInclude(w => w.Currency)
                .FirstOrDefaultAsync(a => a.UserId == userId && a.Name == accountName))?
            .ToAccount();
        
        public async Task<bool> TryChangeAccountValueAsync(string userName, string accountName, string currencyName,
            double value)
        {
            // var user = await _userManager.Users.Where(u => u.UserName == userName).FirstOrDefaultAsync();
            // var account = await GetAccountAsync(user.Id, accountName);
            // if (account == null)
                // return false;
            // var currency = await _walletContext.Currencies
                // .FirstOrDefaultAsync(c => c.Name == currencyName);

            // var wallet = await _walletContext.Wallets.FirstOrDefaultAsync(w =>
                // w.AccountId == account.Id && w.CurrencyId == currency.Id);
            // if (wallet == null)
            // {
                // wallet = new WalletRecord {Currency = currency, Value = value};
                // await _walletContext.Wallets.AddAsync(wallet);
            // }
            // else
                // wallet.Value = value;

            // await _walletContext.SaveChangesAsync();
            return true;
        }
    }
}