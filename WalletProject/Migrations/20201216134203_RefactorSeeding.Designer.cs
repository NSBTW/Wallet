﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Wallet.Database;

namespace Wallet.Migrations
{
    [DbContext(typeof(WalletContext))]
    [Migration("20201216134203_RefactorSeeding")]
    partial class RefactorSeeding
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("name");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_name");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_roles");

                    b.HasIndex("NormalizedName")
                        .IsUnique();

                    b.ToTable("asp_net_roles");

                    b.HasData(
                        new
                        {
                            Id = "d267752e-f8a3-45df-bc5b-e1e19f7353c6",
                            ConcurrencyStamp = "e2b5cb1d-b820-4ead-bfec-c305ecac856c",
                            Name = "admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "72e9bb76-696d-4927-a21e-d7cdd8000e81",
                            ConcurrencyStamp = "05483fa4-4877-40a6-bcc5-81155e5ecfc9",
                            Name = "user",
                            NormalizedName = "USER"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("role_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_role_claims");

                    b.HasIndex("RoleId");

                    b.ToTable("asp_net_role_claims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("ClaimType")
                        .HasColumnType("text")
                        .HasColumnName("claim_type");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("text")
                        .HasColumnName("claim_value");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_user_claims");

                    b.HasIndex("UserId");

                    b.ToTable("asp_net_user_claims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("text")
                        .HasColumnName("provider_key");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("text")
                        .HasColumnName("provider_display_name");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("LoginProvider", "ProviderKey")
                        .HasName("pk_asp_net_user_logins");

                    b.HasIndex("UserId");

                    b.ToTable("asp_net_user_logins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<string>("RoleId")
                        .HasColumnType("text")
                        .HasColumnName("role_id");

                    b.HasKey("UserId", "RoleId")
                        .HasName("pk_asp_net_user_roles");

                    b.HasIndex("RoleId");

                    b.ToTable("asp_net_user_roles");

                    b.HasData(
                        new
                        {
                            UserId = "08810053-4d93-4df7-a081-c39c7f86939d",
                            RoleId = "d267752e-f8a3-45df-bc5b-e1e19f7353c6"
                        },
                        new
                        {
                            UserId = "4357cb03-978c-4cd8-8d26-5948cfe611ff",
                            RoleId = "72e9bb76-696d-4927-a21e-d7cdd8000e81"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("text")
                        .HasColumnName("login_provider");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Value")
                        .HasColumnType("text")
                        .HasColumnName("value");

                    b.HasKey("UserId", "LoginProvider", "Name")
                        .HasName("pk_asp_net_user_tokens");

                    b.ToTable("asp_net_user_tokens");
                });

            modelBuilder.Entity("Wallet.Database.Models.AccountRecord", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_accounts");

                    b.HasIndex("UserId");

                    b.ToTable("accounts");

                    b.HasData(
                        new
                        {
                            Id = "150db9f3-7459-4053-a567-ef3ad504a2a6",
                            Name = "main",
                            UserId = "4357cb03-978c-4cd8-8d26-5948cfe611ff"
                        },
                        new
                        {
                            Id = "629b5c0d-ceca-4334-b431-3bcb9fc9591c",
                            Name = "second",
                            UserId = "4357cb03-978c-4cd8-8d26-5948cfe611ff"
                        },
                        new
                        {
                            Id = "e73e1be7-8370-4a6b-b8af-2f897847430a",
                            Name = "admin",
                            UserId = "4357cb03-978c-4cd8-8d26-5948cfe611ff"
                        });
                });

            modelBuilder.Entity("Wallet.Database.Models.Commissions.CommissionRecord", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("CurrencyId")
                        .HasColumnType("text")
                        .HasColumnName("currency_id");

                    b.Property<double>("MaxCommission")
                        .HasColumnType("double precision")
                        .HasColumnName("max_commission");

                    b.Property<double>("MaxValue")
                        .HasColumnType("double precision")
                        .HasColumnName("max_value");

                    b.Property<double>("MinCommission")
                        .HasColumnType("double precision")
                        .HasColumnName("min_commission");

                    b.Property<int>("OperationType")
                        .HasColumnType("integer")
                        .HasColumnName("operation_type");

                    b.Property<double>("Rate")
                        .HasColumnType("double precision")
                        .HasColumnName("rate");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.Property<double>("Value")
                        .HasColumnType("double precision")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_commissions");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("UserId");

                    b.ToTable("commissions");

                    b.HasData(
                        new
                        {
                            Id = "52d81df7-2732-4968-89f4-9c6a084a5519",
                            CurrencyId = "9e3afc65-d75b-4356-885a-4d4e3cd4ce7f",
                            MaxCommission = 0.0,
                            MaxValue = 100.0,
                            MinCommission = 0.0,
                            OperationType = 0,
                            Rate = 0.0,
                            Type = 0,
                            Value = 1.0
                        },
                        new
                        {
                            Id = "33fc0313-ee5e-42c1-aadd-c8586e58743c",
                            CurrencyId = "9e3afc65-d75b-4356-885a-4d4e3cd4ce7f",
                            MaxCommission = 0.0,
                            MaxValue = 100.0,
                            MinCommission = 0.0,
                            OperationType = 2,
                            Rate = 0.0,
                            Type = 0,
                            Value = 1.0
                        },
                        new
                        {
                            Id = "1efca3ea-1bcd-4b63-8876-436781430e1e",
                            CurrencyId = "9e3afc65-d75b-4356-885a-4d4e3cd4ce7f",
                            MaxCommission = 0.0,
                            MaxValue = 100.0,
                            MinCommission = 0.0,
                            OperationType = 1,
                            Rate = 0.0,
                            Type = 0,
                            Value = 1.0
                        },
                        new
                        {
                            Id = "5ec5a569-8f31-4c37-a3cd-a2157473cb3d",
                            CurrencyId = "33386e00-34b0-4fcd-8c08-37bda6065b27",
                            MaxCommission = 10.0,
                            MaxValue = 50.0,
                            MinCommission = 0.5,
                            OperationType = 0,
                            Rate = 0.10000000000000001,
                            Type = 1,
                            Value = 0.0
                        },
                        new
                        {
                            Id = "e5d97972-0472-41cf-9fd7-18ff7ef63a55",
                            CurrencyId = "33386e00-34b0-4fcd-8c08-37bda6065b27",
                            MaxCommission = 10.0,
                            MaxValue = 50.0,
                            MinCommission = 0.5,
                            OperationType = 2,
                            Rate = 0.10000000000000001,
                            Type = 1,
                            Value = 0.0
                        },
                        new
                        {
                            Id = "42ffbe41-0640-4d0e-a32b-07d845a613cc",
                            CurrencyId = "33386e00-34b0-4fcd-8c08-37bda6065b27",
                            MaxCommission = 10.0,
                            MaxValue = 50.0,
                            MinCommission = 0.5,
                            OperationType = 1,
                            Rate = 0.10000000000000001,
                            Type = 1,
                            Value = 0.0
                        },
                        new
                        {
                            Id = "c248917a-012b-4044-b84d-dac703b0c290",
                            CurrencyId = "9e3afc65-d75b-4356-885a-4d4e3cd4ce7f",
                            MaxCommission = 0.0,
                            MaxValue = 100.0,
                            MinCommission = 0.0,
                            OperationType = 0,
                            Rate = 0.0,
                            Type = 0,
                            Value = 1.0
                        });
                });

            modelBuilder.Entity("Wallet.Database.Models.CurrencyRecord", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_currencies");

                    b.ToTable("currencies");

                    b.HasData(
                        new
                        {
                            Id = "9e3afc65-d75b-4356-885a-4d4e3cd4ce7f",
                            Name = "usd"
                        },
                        new
                        {
                            Id = "33386e00-34b0-4fcd-8c08-37bda6065b27",
                            Name = "eur"
                        });
                });

            modelBuilder.Entity("Wallet.Database.Models.Operations.OperationRecord", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<double>("Commission")
                        .HasColumnType("double precision")
                        .HasColumnName("commission");

                    b.Property<string>("TargetWalletId")
                        .HasColumnType("text")
                        .HasColumnName("target_wallet_id");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.Property<double>("Value")
                        .HasColumnType("double precision")
                        .HasColumnName("value");

                    b.Property<string>("WalletId")
                        .HasColumnType("text")
                        .HasColumnName("wallet_id");

                    b.HasKey("Id")
                        .HasName("pk_operations");

                    b.HasIndex("TargetWalletId");

                    b.HasIndex("WalletId");

                    b.ToTable("operations");
                });

            modelBuilder.Entity("Wallet.Database.Models.UserRecord", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("integer")
                        .HasColumnName("access_failed_count");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("text")
                        .HasColumnName("concurrency_stamp");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("email");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("email_confirmed");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("lockout_enabled");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("lockout_end");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_email");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("normalized_user_name");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("phone_number");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("boolean")
                        .HasColumnName("phone_number_confirmed");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("text")
                        .HasColumnName("security_stamp");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("boolean")
                        .HasColumnName("two_factor_enabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("character varying(256)")
                        .HasColumnName("user_name");

                    b.HasKey("Id")
                        .HasName("pk_asp_net_users");

                    b.HasIndex("NormalizedEmail");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique();

                    b.ToTable("asp_net_users");

                    b.HasData(
                        new
                        {
                            Id = "4357cb03-978c-4cd8-8d26-5948cfe611ff",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "79a6c335-7510-4a8a-8451-cd6f1a475d16",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "USER",
                            PasswordHash = "AQAAAAEAACcQAAAAEEZVT2Db8Dg99rFEB540CRx7NTLW6PqiNpsXAqappW9BLykECq7f96EpwSf8jeAeeA==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "d6ea945b-3751-4b35-a3f5-56bd08edc86a",
                            TwoFactorEnabled = false,
                            UserName = "user"
                        },
                        new
                        {
                            Id = "08810053-4d93-4df7-a081-c39c7f86939d",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "40613831-a846-4b80-ae9f-514fa11b5aac",
                            EmailConfirmed = false,
                            LockoutEnabled = false,
                            NormalizedUserName = "ADMIN",
                            PasswordHash = "AQAAAAEAACcQAAAAEE5C3WhSQygx5SruZhrsRfkb3YU9IHk/4EkFmgm0HsT4R0RTHrUchdAhw27ZAAMyow==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "1076bdc0-b23e-46cb-815a-f167a9bf0592",
                            TwoFactorEnabled = false,
                            UserName = "admin"
                        });
                });

            modelBuilder.Entity("Wallet.Database.Models.WalletRecord", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("AccountId")
                        .HasColumnType("text")
                        .HasColumnName("account_id");

                    b.Property<string>("CurrencyId")
                        .HasColumnType("text")
                        .HasColumnName("currency_id");

                    b.Property<double>("Value")
                        .HasColumnType("double precision")
                        .HasColumnName("value");

                    b.HasKey("Id")
                        .HasName("pk_wallets");

                    b.HasIndex("AccountId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("wallets");

                    b.HasData(
                        new
                        {
                            Id = "1e4bfb42-3a65-4ab3-8064-dacf327eac8b",
                            AccountId = "150db9f3-7459-4053-a567-ef3ad504a2a6",
                            CurrencyId = "9e3afc65-d75b-4356-885a-4d4e3cd4ce7f",
                            Value = 1000.0
                        },
                        new
                        {
                            Id = "b0ec8851-4ceb-499f-ac44-4d4338748e68",
                            AccountId = "629b5c0d-ceca-4334-b431-3bcb9fc9591c",
                            CurrencyId = "33386e00-34b0-4fcd-8c08-37bda6065b27",
                            Value = 2000.0
                        },
                        new
                        {
                            Id = "f33fda2e-a9fb-4f34-b97e-291dcab49059",
                            AccountId = "e73e1be7-8370-4a6b-b8af-2f897847430a",
                            CurrencyId = "9e3afc65-d75b-4356-885a-4d4e3cd4ce7f",
                            Value = 666.0
                        },
                        new
                        {
                            Id = "ed2f4ce7-2cfa-4a92-9fd7-376c6f13de24",
                            AccountId = "e73e1be7-8370-4a6b-b8af-2f897847430a",
                            CurrencyId = "33386e00-34b0-4fcd-8c08-37bda6065b27",
                            Value = 1408.0
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_asp_net_role_claims_asp_net_roles_role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Wallet.Database.Models.UserRecord", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_asp_net_user_claims_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Wallet.Database.Models.UserRecord", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_asp_net_user_logins_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_roles_role_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Wallet.Database.Models.UserRecord", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Wallet.Database.Models.UserRecord", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_asp_net_user_tokens_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wallet.Database.Models.AccountRecord", b =>
                {
                    b.HasOne("Wallet.Database.Models.UserRecord", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_accounts_asp_net_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wallet.Database.Models.Commissions.CommissionRecord", b =>
                {
                    b.HasOne("Wallet.Database.Models.CurrencyRecord", "Currency")
                        .WithMany("Commissions")
                        .HasForeignKey("CurrencyId")
                        .HasConstraintName("fk_commissions_currencies_currency_id");

                    b.HasOne("Wallet.Database.Models.UserRecord", "User")
                        .WithMany("PersonalCommissions")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_commissions_asp_net_users_user_id");

                    b.Navigation("Currency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wallet.Database.Models.Operations.OperationRecord", b =>
                {
                    b.HasOne("Wallet.Database.Models.WalletRecord", "TargetWallet")
                        .WithMany()
                        .HasForeignKey("TargetWalletId")
                        .HasConstraintName("fk_operations_wallets_target_wallet_id");

                    b.HasOne("Wallet.Database.Models.WalletRecord", "Wallet")
                        .WithMany()
                        .HasForeignKey("WalletId")
                        .HasConstraintName("fk_operations_wallets_wallet_id");

                    b.Navigation("TargetWallet");

                    b.Navigation("Wallet");
                });

            modelBuilder.Entity("Wallet.Database.Models.WalletRecord", b =>
                {
                    b.HasOne("Wallet.Database.Models.AccountRecord", "Account")
                        .WithMany("Wallets")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("fk_wallets_accounts_account_id");

                    b.HasOne("Wallet.Database.Models.CurrencyRecord", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .HasConstraintName("fk_wallets_currencies_currency_id");

                    b.Navigation("Account");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Wallet.Database.Models.AccountRecord", b =>
                {
                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("Wallet.Database.Models.CurrencyRecord", b =>
                {
                    b.Navigation("Commissions");
                });

            modelBuilder.Entity("Wallet.Database.Models.UserRecord", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("PersonalCommissions");
                });
#pragma warning restore 612, 618
        }
    }
}
