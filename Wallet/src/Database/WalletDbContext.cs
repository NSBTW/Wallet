using Microsoft.EntityFrameworkCore;
using Wallet.Helpers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Wallet.Database.Models;
using Wallet.Database.Models.Commissions;
using Wallet.Database.Models.Operations;

namespace Wallet.Database
{
    public sealed class WalletDbContext : IdentityDbContext<UserRecord>
    {
        public DbSet<AccountRecord> Accounts { get; set; }
        public DbSet<WalletRecord> Wallets { get; set; }
        public DbSet<CurrencyRecord> Currencies { get; set; }
        
        public DbSet<CommissionRecord> Commissions { get; set; }
        public DbSet<OperationRecord> Operations { get; set; }

        public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            this.ApplySnakeCase(builder);
        }
    }
}