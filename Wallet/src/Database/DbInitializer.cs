using System;
using System.Collections.Generic;
using Wallet.Database.Models;
using Wallet.Database.Models.Commissions;

namespace Wallet.Database
{
    public static class DbInitializer
    {
        public static void InitializeUser(WalletDbContext context, User user)
        {
            var absoluteCommission = new AbsoluteCommission(1) {Id = Guid.NewGuid().ToString()};
            var relativeCommission = new RelativeCommission(0.1, 1, 100) {Id = Guid.NewGuid().ToString()};
            var currency = new Currency
            {
                CommissionsStack = new CommissionsStack(relativeCommission){Id = Guid.NewGuid().ToString()}, Name = "USD",
                Id = Guid.NewGuid().ToString(),
                MaxTransfer = 100
            };
            var wallet = new Models.Wallet {Currency = currency, Value = 666, Id = Guid.NewGuid().ToString()};
            var wallet2 = new Models.Wallet {Currency = currency, Value = 1000, Id = Guid.NewGuid().ToString()};

            var account = new Account
                {Name = "Main", Wallets = new List<Models.Wallet> {wallet}, Id = Guid.NewGuid().ToString()};
            
            var account2 = new Account
                {Name = "Second", Wallets = new List<Models.Wallet> {wallet2}, Id = Guid.NewGuid().ToString()};
            user.Accounts = new List<Account> {account, account2};
            var personalCommission = new PersonalCommission
            {
                Currency = currency,
                CommissionsStack = new CommissionsStack(absoluteCommission) {Id = Guid.NewGuid().ToString()},
                Id = Guid.NewGuid().ToString()
            };
            user.PersonalCommissions = new List<PersonalCommission> {personalCommission};
            context.SaveChanges();
        }
    }
}