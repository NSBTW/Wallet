using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Wallet.Helpers;

namespace Wallet.Database
{
    public sealed class WalletDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

        public WalletDbContext(DbContextOptions<WalletDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<RelativeCommission>();
            builder.Entity<AbsoluteCommission>();
            
            this.ApplySnakeCase(builder);

            AddSomeData(builder);
        }

        private static void AddSomeData(ModelBuilder builder)
        {
            var usdCurrency = new Currency
            {
                CurrencyId = 1,
                Name = "USD",
                Commission = new RelativeCommission(0.1, 1, 100)
            };
            builder.Entity<Currency>().HasData(usdCurrency);
            // var user = new User
            // {
                // UserId = 1,
                // Login = "User", Type = UserType.User, Accounts = new List<Account>
                // {
                    // new Account
                    // {
                        // AccountId = 1,
                        // Name = "Main",
                        // Wallets = new List<Wallet>
                        // {
                            // new Wallet
                            // {
                                // WalletId = 1,
                                // Currency = usdCurrency, Value = 666
                            // }
                        // }
                    // }
                // },

                // PersonalCommissions = new List<PersonalCommission>
                // {
                    // new PersonalCommission
                    // {
                        // PersonalCommissionId = 1,
                        // Commission = new AbsoluteCommission(1) {CommissionBaseId = 2},
                        // Currency = usdCurrency
                    // }
                // }
            // };
            // builder.Entity<User>().HasData(user);
        }
    }
}