using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Wallet.Database.Models;
using Wallet.Database.Models.Commissions;
using Wallet.Database.Models.Operations;

namespace Wallet.Helpers
{
    public static class ModelBuilderExtensions
    {
        public static void SeedWalletContext(this ModelBuilder builder)
        {
            var adminRole = builder.CreateRole("admin");
            var userRole = builder.CreateRole("user");

            var hasher = new PasswordHasher<UserRecord>();

            var user = builder.CreateUser(hasher, "user", "Qwe123!");
            var admin = builder.CreateUser(hasher, "admin", "Qwe123!");

            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string> {RoleId = adminRole.Id, UserId = admin.Id},
                new IdentityUserRole<string> {RoleId = userRole.Id, UserId = user.Id});

            var userMainAccount = builder.CreateAccount(user, "main");
            var userSecondAccount = builder.CreateAccount(user, "second");
            var adminAccount = builder.CreateAccount(admin, "admin");

            var usdCurrency = builder.CreateCurrency("usd");
            var eurCurrency = builder.CreateCurrency("eur");

            builder.CreateWallet(usdCurrency, userMainAccount, 1000);
            builder.CreateWallet(eurCurrency, userSecondAccount, 2000);
            builder.CreateWallet(usdCurrency, adminAccount, 666);
            builder.CreateWallet(eurCurrency, adminAccount, 1408);

            var depositAbsoluteCommission = GetCommission(GetAbsoluteCommission(1), OperationType.Deposit, 100);
            var transferRelativeCommission =
                GetCommission(GetRelativeCommission(0.1, 0.5, 10), OperationType.Transfer, 50);
            builder.CreateCurrencyEqualCommissions(depositAbsoluteCommission, usdCurrency);
            builder.CreateCurrencyEqualCommissions(transferRelativeCommission, eurCurrency);
            builder.CreateUserCommission(admin, depositAbsoluteCommission, eurCurrency, OperationType.Deposit);
        }

        private static IdentityRole CreateRole(this ModelBuilder builder, string name)
        {
            var role = new IdentityRole
                {Id = Guid.NewGuid().ToString(), Name = name, NormalizedName = name.ToUpper()};
            builder.Entity<IdentityRole>().HasData(role);
            return role;
        }

        private static UserRecord CreateUser(this ModelBuilder builder, IPasswordHasher<UserRecord> passwordHasher,
            string name, string password)
        {
            var user = new UserRecord
            {
                Id = Guid.NewGuid().ToString(),
                UserName = name,
                NormalizedUserName = name.ToUpper(),
                PasswordHash = passwordHasher.HashPassword(null, password)
            };
            builder.Entity<UserRecord>().HasData(user);
            return user;
        }

        private static AccountRecord CreateAccount(this ModelBuilder builder, UserRecord user, string name)
        {
            var account = new AccountRecord {Id = Guid.NewGuid().ToString(), Name = name, UserId = user.Id};
            builder.Entity<AccountRecord>().HasData(account);
            return account;
        }

        private static CurrencyRecord CreateCurrency(this ModelBuilder builder, string name)
        {
            var currency = new CurrencyRecord
            {
                Id = Guid.NewGuid().ToString(), Name = name
            };
            builder.Entity<CurrencyRecord>().HasData(currency);
            return currency;
        }

        private static void CreateWallet(this ModelBuilder builder, CurrencyRecord currency,
            AccountRecord account, double value)
        {
            var wallet = new WalletRecord
            {
                Id = Guid.NewGuid().ToString(), CurrencyId = currency.Id, AccountId = account.Id,
                Value = value
            };
            builder.Entity<WalletRecord>().HasData(wallet);
        }

        private static void CreateUserCommission(this ModelBuilder builder, UserRecord user,
            CommissionRecord commissionPattern, CurrencyRecord currency, OperationType type)
        {
            var commission = commissionPattern.CreateSameCommission(type);
            commission.CurrencyId = currency.Id;
            commission.UserId = user.Id;
            builder.Entity<CommissionRecord>().HasData(commission);
        }

        private static void CreateCurrencyEqualCommissions(this ModelBuilder builder,
            CommissionRecord commissionPattern, CurrencyRecord currency)
        {
            commissionPattern.CurrencyId = currency.Id;
            builder.Entity<CommissionRecord>().HasData(commissionPattern.CreateSameCommission(OperationType.Deposit),
                commissionPattern.CreateSameCommission(OperationType.Withdrawal),
                commissionPattern.CreateSameCommission(OperationType.Transfer));
        }

        private static CommissionRecord GetCommission(CommissionRecord commission,
            OperationType operationType, double maxValue)
        {
            commission.Id = Guid.NewGuid().ToString();
            commission.OperationType = operationType;
            commission.MaxValue = maxValue;
            return commission;
        }

        private static CommissionRecord GetAbsoluteCommission(double value) =>
            new CommissionRecord
            {
                Type = CommissionType.Absolute, Value = value
            };

        private static CommissionRecord GetRelativeCommission(double rate, double minValue, double maxValue) =>
            new CommissionRecord
            {
                Type = CommissionType.Relative, Rate = rate, MaxCommission = maxValue, MinCommission = minValue
            };
    }
}