using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
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

            builder.Entity<UserRecord>()
                .Property(u => u.RegistrationDate)
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAdd();
            ConfigureAccountRecord(builder);
            ConfigureOperationsRecord(builder);
            ConfigureWalletRecord(builder);
            ConfigureCurrencyRecord(builder);
            ConfigureCommissionRecord(builder);

            builder.SeedWalletContext();

            this.ApplySnakeCase(builder);
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is OperationRecord && e.State == EntityState.Modified);

            foreach (var entityEntry in entries)
                ((OperationRecord) entityEntry.Entity).UpdatedAt = DateTime.Now;

            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries()
                .Where(e => e.Entity is OperationRecord && e.State == EntityState.Modified);

            foreach (var entityEntry in entries)
                ((OperationRecord) entityEntry.Entity).UpdatedAt = DateTime.Now;
            return (await base.SaveChangesAsync(true, cancellationToken));
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
            builder.Entity<OperationRecord>()
                .Property(u => u.CreatedAt)
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAdd();
            builder.Entity<OperationRecord>()
                .Property(u => u.UpdatedAt)
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAddOrUpdate();

            builder.Entity<OperationRecord>()
                .HasOne(o => o.Wallet)
                .WithMany(w => w.Operations)
                .OnDelete(DeleteBehavior.Cascade);
            builder.Entity<OperationRecord>()
                .HasOne(o => o.TransferWallet)
                .WithMany(w => w.TransferOperations)
                .OnDelete(DeleteBehavior.Cascade);
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
            builder.Entity<CommissionRecord>()
                .HasOne(c => c.User)
                .WithMany(u => u.PersonalCommissions)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}