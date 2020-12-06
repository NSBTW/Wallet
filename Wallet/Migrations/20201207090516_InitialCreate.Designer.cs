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
    [DbContext(typeof(WalletDbContext))]
    [Migration("20201207090516_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityByDefaultColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Wallet.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("account_id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("AccountId")
                        .HasName("pk_accounts");

                    b.HasIndex("UserId");

                    b.ToTable("accounts");

                    b.HasData(
                        new
                        {
                            AccountId = 1,
                            Name = "Main",
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Wallet.Commission", b =>
                {
                    b.Property<int>("CommissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("commission_id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("discriminator");

                    b.HasKey("CommissionId")
                        .HasName("pk_commissions");

                    b.ToTable("commissions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Commission");
                });

            modelBuilder.Entity("Wallet.Currency", b =>
                {
                    b.Property<int>("CurrencyId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("currency_id")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("CommissionId")
                        .HasColumnType("integer")
                        .HasColumnName("commission_id");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("CurrencyId")
                        .HasName("pk_currencies");

                    b.HasIndex("CommissionId");

                    b.ToTable("currencies");

                    b.HasData(
                        new
                        {
                            CurrencyId = 1,
                            CommissionId = 1,
                            Name = "USD"
                        });
                });

            modelBuilder.Entity("Wallet.PersonalCommission", b =>
                {
                    b.Property<int>("PersonalCommissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("personal_commission_id")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("CommissionId")
                        .HasColumnType("integer")
                        .HasColumnName("commission_id");

                    b.Property<int?>("CurrencyId")
                        .HasColumnType("integer")
                        .HasColumnName("currency_id");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer")
                        .HasColumnName("user_id");

                    b.HasKey("PersonalCommissionId")
                        .HasName("pk_personal_commission");

                    b.HasIndex("CommissionId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("UserId");

                    b.ToTable("personal_commission");

                    b.HasData(
                        new
                        {
                            PersonalCommissionId = 1,
                            CommissionId = 2,
                            CurrencyId = 1,
                            UserId = 1
                        });
                });

            modelBuilder.Entity("Wallet.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("user_id")
                        .UseIdentityByDefaultColumn();

                    b.Property<string>("Login")
                        .HasColumnType("text")
                        .HasColumnName("login");

                    b.Property<int>("Type")
                        .HasColumnType("integer")
                        .HasColumnName("type");

                    b.HasKey("UserId")
                        .HasName("pk_users");

                    b.ToTable("users");

                    b.HasData(
                        new
                        {
                            UserId = 1,
                            Login = "User",
                            Type = 0
                        },
                        new
                        {
                            UserId = 2,
                            Login = "Admin",
                            Type = 1
                        });
                });

            modelBuilder.Entity("Wallet.Wallet", b =>
                {
                    b.Property<int>("WalletId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("wallet_id")
                        .UseIdentityByDefaultColumn();

                    b.Property<int?>("AccountId")
                        .HasColumnType("integer")
                        .HasColumnName("account_id");

                    b.Property<int?>("CurrencyId")
                        .HasColumnType("integer")
                        .HasColumnName("currency_id");

                    b.Property<double>("Value")
                        .HasColumnType("double precision")
                        .HasColumnName("value");

                    b.HasKey("WalletId")
                        .HasName("pk_wallets");

                    b.HasIndex("AccountId");

                    b.HasIndex("CurrencyId");

                    b.ToTable("wallets");

                    b.HasData(
                        new
                        {
                            WalletId = 1,
                            AccountId = 1,
                            CurrencyId = 1,
                            Value = 666.0
                        });
                });

            modelBuilder.Entity("Wallet.AbsoluteCommission", b =>
                {
                    b.HasBaseType("Wallet.Commission");

                    b.Property<double>("Commission")
                        .HasColumnType("double precision")
                        .HasColumnName("commission");

                    b.ToTable("commissions");

                    b.HasDiscriminator().HasValue("AbsoluteCommission");

                    b.HasData(
                        new
                        {
                            CommissionId = 2,
                            Commission = 1.0
                        });
                });

            modelBuilder.Entity("Wallet.RelativeCommission", b =>
                {
                    b.HasBaseType("Wallet.Commission");

                    b.Property<double>("MaximalCommission")
                        .HasColumnType("double precision")
                        .HasColumnName("maximal_commission");

                    b.Property<double>("MinimalCommission")
                        .HasColumnType("double precision")
                        .HasColumnName("minimal_commission");

                    b.Property<double>("Rate")
                        .HasColumnType("double precision")
                        .HasColumnName("rate");

                    b.ToTable("commissions");

                    b.HasDiscriminator().HasValue("RelativeCommission");

                    b.HasData(
                        new
                        {
                            CommissionId = 1,
                            MaximalCommission = 100.0,
                            MinimalCommission = 1.0,
                            Rate = 0.10000000000000001
                        });
                });

            modelBuilder.Entity("Wallet.Account", b =>
                {
                    b.HasOne("Wallet.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_accounts_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wallet.Currency", b =>
                {
                    b.HasOne("Wallet.Commission", "Commission")
                        .WithMany()
                        .HasForeignKey("CommissionId")
                        .HasConstraintName("fk_currencies_commissions_commission_id");

                    b.Navigation("Commission");
                });

            modelBuilder.Entity("Wallet.PersonalCommission", b =>
                {
                    b.HasOne("Wallet.Commission", "Commission")
                        .WithMany()
                        .HasForeignKey("CommissionId")
                        .HasConstraintName("fk_personal_commission_commissions_commission_id");

                    b.HasOne("Wallet.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .HasConstraintName("fk_personal_commission_currencies_currency_id");

                    b.HasOne("Wallet.User", "User")
                        .WithMany("PersonalCommissions")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_personal_commission_users_user_id");

                    b.Navigation("Commission");

                    b.Navigation("Currency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wallet.Wallet", b =>
                {
                    b.HasOne("Wallet.Account", "Account")
                        .WithMany("Wallets")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("fk_wallets_accounts_account_id");

                    b.HasOne("Wallet.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .HasConstraintName("fk_wallets_currencies_currency_id");

                    b.Navigation("Account");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Wallet.Account", b =>
                {
                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("Wallet.User", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("PersonalCommissions");
                });
#pragma warning restore 612, 618
        }
    }
}
