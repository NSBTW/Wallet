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

            var userMainAccount = builder.CreateAccount(user, "main", 1);
            var userSecondAccount = builder.CreateAccount(user, "second", 2);
            var adminAccount = builder.CreateAccount(admin, "admin", 3);

            var usdCurrency = builder.CreateCurrency("usd", 1);
            var eurCurrency = builder.CreateCurrency("eur", 2);

            builder.CreateWallet(usdCurrency, userMainAccount, 1000, 1);
            builder.CreateWallet(eurCurrency, userSecondAccount, 2000, 2);
            builder.CreateWallet(usdCurrency, adminAccount, 666, 3);
            builder.CreateWallet(eurCurrency, adminAccount, 1408, 4);

            var depositAbsoluteCommission = GetCommission(GetAbsoluteCommission(1), OperationType.Deposit, 100, 1);
            var transferRelativeCommission =
                GetCommission(GetRelativeCommission(0.1, 0.5, 10), OperationType.Transfer, 50, 2);
            builder.CreateCurrencyEqualCommissions(depositAbsoluteCommission, usdCurrency, 10);
            builder.CreateCurrencyEqualCommissions(transferRelativeCommission, eurCurrency, 20);
            builder.CreateUserCommission(admin, depositAbsoluteCommission, eurCurrency, OperationType.Deposit, 30);
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
                PasswordHash = passwordHasher.HashPassword(null, password),
                RegistrationDate = DateTime.Now
            };
            builder.Entity<UserRecord>().HasData(user);
            return user;
        }

        private static AccountRecord CreateAccount(this ModelBuilder builder, UserRecord user, string name, int id)
        {
            var account = new AccountRecord {Id = id, Name = name, UserId = user.Id};
            builder.Entity<AccountRecord>().HasData(account);
            return account;
        }

        private static CurrencyRecord CreateCurrency(this ModelBuilder builder, string name, int id)
        {
            var currency = new CurrencyRecord
            {
                Id = id, Name = name
            };
            builder.Entity<CurrencyRecord>().HasData(currency);
            return currency;
        }

        private static void CreateWallet(this ModelBuilder builder, CurrencyRecord currency,
            AccountRecord account, double value, int id)
        {
            var wallet = new WalletRecord
            {
                Id = id, CurrencyId = currency.Id, AccountId = account.Id,
                Value = value
            };
            builder.Entity<WalletRecord>().HasData(wallet);
        }

        private static void CreateUserCommission(this ModelBuilder builder, UserRecord user,
            CommissionRecord commissionPattern, CurrencyRecord currency, OperationType type, int mul)
        {
            var commission = commissionPattern.CreateSameCommission(type, mul * commissionPattern.Id + 1);
            commission.CurrencyId = currency.Id;
            commission.UserId = user.Id;
            builder.Entity<CommissionRecord>().HasData(commission);
        }

        private static void CreateCurrencyEqualCommissions(this ModelBuilder builder,
            CommissionRecord commissionPattern, CurrencyRecord currency, int mul)
        {
            commissionPattern.CurrencyId = currency.Id;
            builder.Entity<CommissionRecord>().HasData(
                commissionPattern.CreateSameCommission(OperationType.Deposit, mul * commissionPattern.Id + 1),
                commissionPattern.CreateSameCommission(OperationType.Withdrawal, mul * commissionPattern.Id + 2),
                commissionPattern.CreateSameCommission(OperationType.Transfer, mul * commissionPattern.Id + 3));
        }

        private static CommissionRecord GetCommission(CommissionRecord commission,
            OperationType operationType, double maxValue, int id)
        {
            commission.Id = id;
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