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
    [Migration("20201207181620_MaxTransfer")]
    partial class MaxTransfer
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

            modelBuilder.Entity("Wallet.Database.Models.Account", b =>
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
                });

            modelBuilder.Entity("Wallet.Database.Models.Commissions.Commission", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("discriminator");

                    b.HasKey("Id")
                        .HasName("pk_commissions");

                    b.ToTable("commissions");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Commission");
                });

            modelBuilder.Entity("Wallet.Database.Models.Commissions.CommissionsStack", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("DepositCommissionId")
                        .HasColumnType("text")
                        .HasColumnName("deposit_commission_id");

                    b.Property<string>("OutCommissionId")
                        .HasColumnType("text")
                        .HasColumnName("out_commission_id");

                    b.Property<string>("TransferCommissionId")
                        .HasColumnType("text")
                        .HasColumnName("transfer_commission_id");

                    b.HasKey("Id")
                        .HasName("pk_commissions_stack");

                    b.HasIndex("DepositCommissionId");

                    b.HasIndex("OutCommissionId");

                    b.HasIndex("TransferCommissionId");

                    b.ToTable("commissions_stack");
                });

            modelBuilder.Entity("Wallet.Database.Models.Currency", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("CommissionsStackId")
                        .HasColumnType("text")
                        .HasColumnName("commissions_stack_id");

                    b.Property<double>("MaxTransfer")
                        .HasColumnType("double precision")
                        .HasColumnName("max_transfer");

                    b.Property<string>("Name")
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_currencies");

                    b.HasIndex("CommissionsStackId");

                    b.ToTable("currencies");
                });

            modelBuilder.Entity("Wallet.Database.Models.PersonalCommission", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text")
                        .HasColumnName("id");

                    b.Property<string>("CommissionsStackId")
                        .HasColumnType("text")
                        .HasColumnName("commissions_stack_id");

                    b.Property<string>("CurrencyId")
                        .HasColumnType("text")
                        .HasColumnName("currency_id");

                    b.Property<string>("UserId")
                        .HasColumnType("text")
                        .HasColumnName("user_id");

                    b.HasKey("Id")
                        .HasName("pk_personal_commissions");

                    b.HasIndex("CommissionsStackId");

                    b.HasIndex("CurrencyId");

                    b.HasIndex("UserId");

                    b.ToTable("personal_commissions");
                });

            modelBuilder.Entity("Wallet.Database.Models.User", b =>
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
                });

            modelBuilder.Entity("Wallet.Database.Models.Wallet", b =>
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
                });

            modelBuilder.Entity("Wallet.Database.Models.Commissions.AbsoluteCommission", b =>
                {
                    b.HasBaseType("Wallet.Database.Models.Commissions.Commission");

                    b.Property<double>("Commission")
                        .HasColumnType("double precision")
                        .HasColumnName("commission");

                    b.ToTable("commissions");

                    b.HasDiscriminator().HasValue("AbsoluteCommission");
                });

            modelBuilder.Entity("Wallet.Database.Models.Commissions.RelativeCommission", b =>
                {
                    b.HasBaseType("Wallet.Database.Models.Commissions.Commission");

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
                    b.HasOne("Wallet.Database.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_asp_net_user_claims_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Wallet.Database.Models.User", null)
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

                    b.HasOne("Wallet.Database.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_asp_net_user_roles_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Wallet.Database.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_asp_net_user_tokens_asp_net_users_user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Wallet.Database.Models.Account", b =>
                {
                    b.HasOne("Wallet.Database.Models.User", "User")
                        .WithMany("Accounts")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_accounts_asp_net_users_user_id");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wallet.Database.Models.Commissions.CommissionsStack", b =>
                {
                    b.HasOne("Wallet.Database.Models.Commissions.Commission", "DepositCommission")
                        .WithMany()
                        .HasForeignKey("DepositCommissionId")
                        .HasConstraintName("fk_commissions_stack_commissions_deposit_commission_id");

                    b.HasOne("Wallet.Database.Models.Commissions.Commission", "OutCommission")
                        .WithMany()
                        .HasForeignKey("OutCommissionId")
                        .HasConstraintName("fk_commissions_stack_commissions_out_commission_id");

                    b.HasOne("Wallet.Database.Models.Commissions.Commission", "TransferCommission")
                        .WithMany()
                        .HasForeignKey("TransferCommissionId")
                        .HasConstraintName("fk_commissions_stack_commissions_transfer_commission_id");

                    b.Navigation("DepositCommission");

                    b.Navigation("OutCommission");

                    b.Navigation("TransferCommission");
                });

            modelBuilder.Entity("Wallet.Database.Models.Currency", b =>
                {
                    b.HasOne("Wallet.Database.Models.Commissions.CommissionsStack", "CommissionsStack")
                        .WithMany()
                        .HasForeignKey("CommissionsStackId")
                        .HasConstraintName("fk_currencies_commissions_stack_commissions_stack_id");

                    b.Navigation("CommissionsStack");
                });

            modelBuilder.Entity("Wallet.Database.Models.PersonalCommission", b =>
                {
                    b.HasOne("Wallet.Database.Models.Commissions.CommissionsStack", "CommissionsStack")
                        .WithMany()
                        .HasForeignKey("CommissionsStackId")
                        .HasConstraintName("fk_personal_commissions_commissions_stack_commissions_stack_id");

                    b.HasOne("Wallet.Database.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .HasConstraintName("fk_personal_commissions_currencies_currency_id");

                    b.HasOne("Wallet.Database.Models.User", "User")
                        .WithMany("PersonalCommissions")
                        .HasForeignKey("UserId")
                        .HasConstraintName("fk_personal_commissions_asp_net_users_user_id");

                    b.Navigation("CommissionsStack");

                    b.Navigation("Currency");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Wallet.Database.Models.Wallet", b =>
                {
                    b.HasOne("Wallet.Database.Models.Account", "Account")
                        .WithMany("Wallets")
                        .HasForeignKey("AccountId")
                        .HasConstraintName("fk_wallets_accounts_account_id");

                    b.HasOne("Wallet.Database.Models.Currency", "Currency")
                        .WithMany()
                        .HasForeignKey("CurrencyId")
                        .HasConstraintName("fk_wallets_currencies_currency_id");

                    b.Navigation("Account");

                    b.Navigation("Currency");
                });

            modelBuilder.Entity("Wallet.Database.Models.Account", b =>
                {
                    b.Navigation("Wallets");
                });

            modelBuilder.Entity("Wallet.Database.Models.User", b =>
                {
                    b.Navigation("Accounts");

                    b.Navigation("PersonalCommissions");
                });
#pragma warning restore 612, 618
        }
    }
}
