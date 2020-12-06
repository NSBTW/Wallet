using System;
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
        public DbSet<Commission> Commissions { get; set; }

        public WalletDbContext(DbContextOptions<WalletDbContext> options)
            : base(options)
        {
            Database.EnsureDeleted();
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
            builder.Entity<RelativeCommission>()
                .HasData(new RelativeCommission(0.1, 1, 100) {CommissionId = 1});
            builder.Entity<AbsoluteCommission>().HasData(new AbsoluteCommission(1) {CommissionId = 2});
            
            builder.Entity<Currency>().HasData(new {CurrencyId = 1, Name = "USD", CommissionId = 1});

            builder.Entity<Wallet>().HasData(new {WalletId = 1, CurrencyId = 1, Value = 666d, AccountId = 1});
            builder.Entity<Account>().HasData(new {AccountId = 1, Name = "Main",UserId = 1});
            
            builder.Entity<User>().HasData(new {UserId = 1, Login = "User", Type = UserType.User},
                new {UserId = 2, Login = "Admin", Type = UserType.Admin});
            
            builder.Entity<PersonalCommission>()
                .HasData(new {UserId = 1, PersonalCommissionId = 1, CommissionId=2, CurrencyId=1});

        }
    }
}