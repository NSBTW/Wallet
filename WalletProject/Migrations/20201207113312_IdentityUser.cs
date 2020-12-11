using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Wallet.Migrations
{
    public partial class IdentityUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_accounts_users_user_id",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "fk_currencies_commissions_commission_id",
                table: "currencies");

            migrationBuilder.DropForeignKey(
                name: "fk_personal_commission_commissions_commission_id",
                table: "personal_commission");

            migrationBuilder.DropForeignKey(
                name: "fk_personal_commission_currencies_currency_id",
                table: "personal_commission");

            migrationBuilder.DropForeignKey(
                name: "fk_personal_commission_users_user_id",
                table: "personal_commission");

            migrationBuilder.DropForeignKey(
                name: "fk_wallets_accounts_account_id",
                table: "wallets");

            migrationBuilder.DropForeignKey(
                name: "fk_wallets_currencies_currency_id",
                table: "wallets");

            migrationBuilder.DropPrimaryKey(
                name: "pk_wallets",
                table: "wallets");

            migrationBuilder.DropPrimaryKey(
                name: "pk_personal_commission",
                table: "personal_commission");

            migrationBuilder.DropPrimaryKey(
                name: "pk_currencies",
                table: "currencies");

            migrationBuilder.DropPrimaryKey(
                name: "pk_commissions",
                table: "commissions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_accounts",
                table: "accounts");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "users");

            migrationBuilder.DeleteData(
                table: "personal_commission",
                keyColumn: "personal_commission_id",
                keyColumnType: "integer",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyColumnType: "integer",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "wallets",
                keyColumn: "wallet_id",
                keyColumnType: "integer",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "accounts",
                keyColumn: "account_id",
                keyColumnType: "integer",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "commissions",
                keyColumn: "commission_id",
                keyColumnType: "integer",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "currencies",
                keyColumn: "currency_id",
                keyColumnType: "integer",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "commissions",
                keyColumn: "commission_id",
                keyColumnType: "integer",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "users",
                keyColumn: "user_id",
                keyColumnType: "integer",
                keyValue: 1);

            migrationBuilder.DropColumn(
                name: "wallet_id",
                table: "wallets");

            migrationBuilder.DropColumn(
                name: "personal_commission_id",
                table: "personal_commission");

            migrationBuilder.DropColumn(
                name: "currency_id",
                table: "currencies");

            migrationBuilder.DropColumn(
                name: "commission_id",
                table: "commissions");

            migrationBuilder.DropColumn(
                name: "account_id",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "user_id",
                table: "users");

            migrationBuilder.RenameTable(
                name: "users",
                newName: "asp_net_users");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "asp_net_users",
                newName: "access_failed_count");

            migrationBuilder.RenameColumn(
                name: "login",
                table: "asp_net_users",
                newName: "security_stamp");

            migrationBuilder.AlterColumn<string>(
                name: "currency_id",
                table: "wallets",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "account_id",
                table: "wallets",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "wallets",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "personal_commission",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "currency_id",
                table: "personal_commission",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "commission_id",
                table: "personal_commission",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "personal_commission",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "commission_id",
                table: "currencies",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "currencies",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "commissions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "accounts",
                type: "text",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "accounts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "id",
                table: "asp_net_users",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "concurrency_stamp",
                table: "asp_net_users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "email",
                table: "asp_net_users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "email_confirmed",
                table: "asp_net_users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "lockout_enabled",
                table: "asp_net_users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTimeOffset>(
                name: "lockout_end",
                table: "asp_net_users",
                type: "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "normalized_email",
                table: "asp_net_users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "normalized_user_name",
                table: "asp_net_users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "password_hash",
                table: "asp_net_users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "phone_number",
                table: "asp_net_users",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "phone_number_confirmed",
                table: "asp_net_users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "two_factor_enabled",
                table: "asp_net_users",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "user_name",
                table: "asp_net_users",
                type: "character varying(256)",
                maxLength: 256,
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_wallets",
                table: "wallets",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_personal_commission",
                table: "personal_commission",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_currencies",
                table: "currencies",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_commissions",
                table: "commissions",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_accounts",
                table: "accounts",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_asp_net_users",
                table: "asp_net_users",
                column: "id");

            migrationBuilder.CreateTable(
                name: "asp_net_roles",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_user_claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<string>(type: "text", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_user_claims_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_user_logins",
                columns: table => new
                {
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    provider_key = table.Column<string>(type: "text", nullable: false),
                    provider_display_name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_logins", x => new { x.login_provider, x.provider_key });
                    table.ForeignKey(
                        name: "fk_asp_net_user_logins_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_user_tokens",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    login_provider = table.Column<string>(type: "text", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_tokens", x => new { x.user_id, x.login_provider, x.name });
                    table.ForeignKey(
                        name: "fk_asp_net_user_tokens_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_role_claims",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    role_id = table.Column<string>(type: "text", nullable: false),
                    claim_type = table.Column<string>(type: "text", nullable: true),
                    claim_value = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_role_claims", x => x.id);
                    table.ForeignKey(
                        name: "fk_asp_net_role_claims_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "asp_net_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "asp_net_user_roles",
                columns: table => new
                {
                    user_id = table.Column<string>(type: "text", nullable: false),
                    role_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_user_roles", x => new { x.user_id, x.role_id });
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "asp_net_roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_asp_net_user_roles_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_asp_net_users_normalized_email",
                table: "asp_net_users",
                column: "normalized_email");

            migrationBuilder.CreateIndex(
                name: "IX_asp_net_users_normalized_user_name",
                table: "asp_net_users",
                column: "normalized_user_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_asp_net_role_claims_role_id",
                table: "asp_net_role_claims",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_asp_net_roles_normalized_name",
                table: "asp_net_roles",
                column: "normalized_name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_asp_net_user_claims_user_id",
                table: "asp_net_user_claims",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_asp_net_user_logins_user_id",
                table: "asp_net_user_logins",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_asp_net_user_roles_role_id",
                table: "asp_net_user_roles",
                column: "role_id");

            migrationBuilder.AddForeignKey(
                name: "fk_accounts_asp_net_users_user_id",
                table: "accounts",
                column: "user_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_currencies_commissions_commission_id",
                table: "currencies",
                column: "commission_id",
                principalTable: "commissions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_personal_commission_asp_net_users_user_id",
                table: "personal_commission",
                column: "user_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_personal_commission_commissions_commission_id",
                table: "personal_commission",
                column: "commission_id",
                principalTable: "commissions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_personal_commission_currencies_currency_id",
                table: "personal_commission",
                column: "currency_id",
                principalTable: "currencies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_wallets_accounts_account_id",
                table: "wallets",
                column: "account_id",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_wallets_currencies_currency_id",
                table: "wallets",
                column: "currency_id",
                principalTable: "currencies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_accounts_asp_net_users_user_id",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "fk_currencies_commissions_commission_id",
                table: "currencies");

            migrationBuilder.DropForeignKey(
                name: "fk_personal_commission_asp_net_users_user_id",
                table: "personal_commission");

            migrationBuilder.DropForeignKey(
                name: "fk_personal_commission_commissions_commission_id",
                table: "personal_commission");

            migrationBuilder.DropForeignKey(
                name: "fk_personal_commission_currencies_currency_id",
                table: "personal_commission");

            migrationBuilder.DropForeignKey(
                name: "fk_wallets_accounts_account_id",
                table: "wallets");

            migrationBuilder.DropForeignKey(
                name: "fk_wallets_currencies_currency_id",
                table: "wallets");

            migrationBuilder.DropTable(
                name: "asp_net_role_claims");

            migrationBuilder.DropTable(
                name: "asp_net_user_claims");

            migrationBuilder.DropTable(
                name: "asp_net_user_logins");

            migrationBuilder.DropTable(
                name: "asp_net_user_roles");

            migrationBuilder.DropTable(
                name: "asp_net_user_tokens");

            migrationBuilder.DropTable(
                name: "asp_net_roles");

            migrationBuilder.DropPrimaryKey(
                name: "pk_wallets",
                table: "wallets");

            migrationBuilder.DropPrimaryKey(
                name: "pk_personal_commission",
                table: "personal_commission");

            migrationBuilder.DropPrimaryKey(
                name: "pk_currencies",
                table: "currencies");

            migrationBuilder.DropPrimaryKey(
                name: "pk_commissions",
                table: "commissions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_accounts",
                table: "accounts");

            migrationBuilder.DropPrimaryKey(
                name: "pk_asp_net_users",
                table: "asp_net_users");

            migrationBuilder.DropIndex(
                name: "IX_asp_net_users_normalized_email",
                table: "asp_net_users");

            migrationBuilder.DropIndex(
                name: "IX_asp_net_users_normalized_user_name",
                table: "asp_net_users");

            migrationBuilder.DropColumn(
                name: "id",
                table: "wallets");

            migrationBuilder.DropColumn(
                name: "id",
                table: "personal_commission");

            migrationBuilder.DropColumn(
                name: "id",
                table: "currencies");

            migrationBuilder.DropColumn(
                name: "id",
                table: "commissions");

            migrationBuilder.DropColumn(
                name: "id",
                table: "accounts");

            migrationBuilder.DropColumn(
                name: "id",
                table: "asp_net_users");

            migrationBuilder.DropColumn(
                name: "concurrency_stamp",
                table: "asp_net_users");

            migrationBuilder.DropColumn(
                name: "email",
                table: "asp_net_users");

            migrationBuilder.DropColumn(
                name: "email_confirmed",
                table: "asp_net_users");

            migrationBuilder.DropColumn(
                name: "lockout_enabled",
                table: "asp_net_users");

            migrationBuilder.DropColumn(
                name: "lockout_end",
                table: "asp_net_users");

            migrationBuilder.DropColumn(
                name: "normalized_email",
                table: "asp_net_users");

            migrationBuilder.DropColumn(
                name: "normalized_user_name",
                table: "asp_net_users");

            migrationBuilder.DropColumn(
                name: "password_hash",
                table: "asp_net_users");

            migrationBuilder.DropColumn(
                name: "phone_number",
                table: "asp_net_users");

            migrationBuilder.DropColumn(
                name: "phone_number_confirmed",
                table: "asp_net_users");

            migrationBuilder.DropColumn(
                name: "two_factor_enabled",
                table: "asp_net_users");

            migrationBuilder.DropColumn(
                name: "user_name",
                table: "asp_net_users");

            migrationBuilder.RenameTable(
                name: "asp_net_users",
                newName: "users");

            migrationBuilder.RenameColumn(
                name: "security_stamp",
                table: "users",
                newName: "login");

            migrationBuilder.RenameColumn(
                name: "access_failed_count",
                table: "users",
                newName: "type");

            migrationBuilder.AlterColumn<int>(
                name: "currency_id",
                table: "wallets",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "account_id",
                table: "wallets",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "wallet_id",
                table: "wallets",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "personal_commission",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "currency_id",
                table: "personal_commission",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "commission_id",
                table: "personal_commission",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "personal_commission_id",
                table: "personal_commission",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "commission_id",
                table: "currencies",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "currency_id",
                table: "currencies",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "commission_id",
                table: "commissions",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "user_id",
                table: "accounts",
                type: "integer",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "account_id",
                table: "accounts",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "user_id",
                table: "users",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddPrimaryKey(
                name: "pk_wallets",
                table: "wallets",
                column: "wallet_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_personal_commission",
                table: "personal_commission",
                column: "personal_commission_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_currencies",
                table: "currencies",
                column: "currency_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_commissions",
                table: "commissions",
                column: "commission_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_accounts",
                table: "accounts",
                column: "account_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "users",
                column: "user_id");

            migrationBuilder.InsertData(
                table: "commissions",
                columns: new[] { "commission_id", "commission", "discriminator" },
                values: new object[] { 2, 1.0, "AbsoluteCommission" });

            migrationBuilder.InsertData(
                table: "commissions",
                columns: new[] { "commission_id", "discriminator", "maximal_commission", "minimal_commission", "rate" },
                values: new object[] { 1, "RelativeCommission", 100.0, 1.0, 0.10000000000000001 });

            migrationBuilder.InsertData(
                table: "users",
                columns: new[] { "user_id", "login", "type" },
                values: new object[,]
                {
                    { 1, "User", 0 },
                    { 2, "Admin", 1 }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "account_id", "name", "user_id" },
                values: new object[] { 1, "Main", 1 });

            migrationBuilder.InsertData(
                table: "currencies",
                columns: new[] { "currency_id", "commission_id", "name" },
                values: new object[] { 1, 1, "USD" });

            migrationBuilder.InsertData(
                table: "personal_commission",
                columns: new[] { "personal_commission_id", "commission_id", "currency_id", "user_id" },
                values: new object[] { 1, 2, 1, 1 });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "wallet_id", "account_id", "currency_id", "value" },
                values: new object[] { 1, 1, 1, 666.0 });

            migrationBuilder.AddForeignKey(
                name: "fk_accounts_users_user_id",
                table: "accounts",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_currencies_commissions_commission_id",
                table: "currencies",
                column: "commission_id",
                principalTable: "commissions",
                principalColumn: "commission_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_personal_commission_commissions_commission_id",
                table: "personal_commission",
                column: "commission_id",
                principalTable: "commissions",
                principalColumn: "commission_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_personal_commission_currencies_currency_id",
                table: "personal_commission",
                column: "currency_id",
                principalTable: "currencies",
                principalColumn: "currency_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_personal_commission_users_user_id",
                table: "personal_commission",
                column: "user_id",
                principalTable: "users",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_wallets_accounts_account_id",
                table: "wallets",
                column: "account_id",
                principalTable: "accounts",
                principalColumn: "account_id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_wallets_currencies_currency_id",
                table: "wallets",
                column: "currency_id",
                principalTable: "currencies",
                principalColumn: "currency_id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
