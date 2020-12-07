using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Wallet.Helpers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Wallet.Database.Models;
using Wallet.Database.Models.Commissions;
using Wallet.Database.Models.Operations;

namespace Wallet.Database
{
    public sealed class WalletDbContext : IdentityDbContext<User>
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<Models.Wallet> Wallets { get; set; }
        public DbSet<Commission> Commissions { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<PersonalCommission> PersonalCommissions { get; set; }

        public WalletDbContext(DbContextOptions<WalletDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<RelativeCommission>();
            builder.Entity<AbsoluteCommission>();
            builder.Entity<TransferOperation>();
            builder.Entity<OutOperation>();
            builder.Entity<DepositOperation>();

            this.ApplySnakeCase(builder);
        }
    }
}