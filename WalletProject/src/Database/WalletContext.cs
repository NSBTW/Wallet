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
            
            builder.SeedWalletContext();

            this.ApplySnakeCase(builder);
        }
    }
}