using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Wallet.Database.Models;
using Wallet.Database.Models.Commissions;
using Wallet.Database.Models.Operations;
using Wallet.Helpers;

namespace Wallet.Database
{
    public sealed class WalletContext : IdentityDbContext<UserRecord>
    {
        public DbSet<AccountRecord> Accounts { get; set; }
        public DbSet<WalletRecord> Wallets { get; set; }
        public DbSet<CurrencyRecord> Currencies { get; set; }

        public DbSet<CommissionRecord> Commissions { get; set; }
        public DbSet<OperationRecord> Operations { get; set; }

        public WalletContext(DbContextOptions<WalletContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            ConfigureAccountRecord(builder);
            ConfigureOperationsRecord(builder);
            ConfigureWalletRecord(builder);
            ConfigureCurrencyRecord(builder);
            ConfigureCommissionRecord(builder);

            builder.SeedWalletContext();

            this.ApplySnakeCase(builder);
        }

        private static void ConfigureAccountRecord(ModelBuilder builder)
        {
            builder.Entity<AccountRecord>().Property(a => a.Name).IsRequired();
            builder.Entity<AccountRecord>().Property(a => a.UserId).IsRequired();
        }

        private static void ConfigureOperationsRecord(ModelBuilder builder)
        {
            builder.Entity<OperationRecord>().Property(o => o.Type).IsRequired();
            builder.Entity<OperationRecord>().Property(o => o.WalletId).IsRequired();

        }

        private static void ConfigureWalletRecord(ModelBuilder builder)
        {
            builder.Entity<WalletRecord>().Property(a => a.CurrencyId).IsRequired();
            builder.Entity<WalletRecord>().Property(a => a.AccountId).IsRequired();
        }

        private static void ConfigureCurrencyRecord(ModelBuilder builder)
        {
            builder.Entity<CurrencyRecord>().Property(a => a.Name).IsRequired();
            builder.Entity<CurrencyRecord>().HasIndex(c => c.Name).IsUnique();
        }

        private static void ConfigureCommissionRecord(ModelBuilder builder)
        {
            builder.Entity<CommissionRecord>().Property(a => a.Type).IsRequired();
            builder.Entity<CommissionRecord>().Property(a => a.OperationType).IsRequired();
            builder.Entity<CommissionRecord>().Property(a => a.CurrencyId).IsRequired();
        }
    }
}