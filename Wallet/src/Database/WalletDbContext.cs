using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Wallet.Helpers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Wallet.Database
{
    public sealed class WalletDbContext : IdentityDbContext<User>
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Commission> Commissions { get; set; }

        public WalletDbContext(DbContextOptions<WalletDbContext> options):base(options){}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RelativeCommission>();
            builder.Entity<AbsoluteCommission>();

            this.ApplySnakeCase(builder);
        }

    }
}