using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Wallet.Migrations
{
    public partial class NullableTransferId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "asp_net_users",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    registration_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_user_name = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    normalized_email = table.Column<string>(type: "character varying(256)", maxLength: 256, nullable: true),
                    email_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    password_hash = table.Column<string>(type: "text", nullable: true),
                    security_stamp = table.Column<string>(type: "text", nullable: true),
                    concurrency_stamp = table.Column<string>(type: "text", nullable: true),
                    phone_number = table.Column<string>(type: "text", nullable: true),
                    phone_number_confirmed = table.Column<bool>(type: "boolean", nullable: false),
                    two_factor_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    lockout_end = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    lockout_enabled = table.Column<bool>(type: "boolean", nullable: false),
                    access_failed_count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_asp_net_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "currencies",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_currencies", x => x.id);
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
                name: "accounts",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accounts", x => x.id);
                    table.ForeignKey(
                        name: "fk_accounts_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                name: "commissions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<int>(type: "integer", nullable: false),
                    operation_type = table.Column<int>(type: "integer", nullable: false),
                    value = table.Column<double>(type: "double precision", nullable: false),
                    rate = table.Column<double>(type: "double precision", nullable: false),
                    max_commission = table.Column<double>(type: "double precision", nullable: false),
                    min_commission = table.Column<double>(type: "double precision", nullable: false),
                    max_value = table.Column<double>(type: "double precision", nullable: false),
                    user_id = table.Column<string>(type: "text", nullable: true),
                    currency_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_commissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_commissions_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commissions_currencies_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "wallets",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    value = table.Column<double>(type: "double precision", nullable: false),
                    account_id = table.Column<int>(type: "integer", nullable: false),
                    currency_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_wallets", x => x.id);
                    table.ForeignKey(
                        name: "fk_wallets_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_wallets_currencies_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "operations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    type = table.Column<int>(type: "integer", nullable: false),
                    value = table.Column<double>(type: "double precision", nullable: false),
                    commission = table.Column<double>(type: "double precision", nullable: false),
                    wallet_id = table.Column<int>(type: "integer", nullable: false),
                    transfer_wallet_id = table.Column<int>(type: "integer", nullable: true),
                    is_completed = table.Column<bool>(type: "boolean", nullable: false),
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_operations", x => x.id);
                    table.ForeignKey(
                        name: "fk_operations_wallets_transfer_wallet_id",
                        column: x => x.transfer_wallet_id,
                        principalTable: "wallets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_operations_wallets_wallet_id",
                        column: x => x.wallet_id,
                        principalTable: "wallets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "asp_net_roles",
                columns: new[] { "id", "concurrency_stamp", "name", "normalized_name" },
                values: new object[,]
                {
                    { "0d71f2e3-2af6-48ab-b6a7-145633ebb0a4", "861d51c1-e3e3-4e27-8b86-efdbbbe93c18", "admin", "ADMIN" },
                    { "4b465d67-5641-4dd6-bc15-30516b0e5b9a", "22b6a38f-0da5-45b6-ae7e-afb6d3cc427e", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "registration_date", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[,]
                {
                    { "a2dea8b4-79b4-4136-bafe-721b4078d0b0", 0, "1c3c66d0-4eca-426d-bc2d-86bba194086c", null, false, false, null, null, "USER", "AQAAAAEAACcQAAAAEKbXTmZ53JHfBUCXwQk7xoQbhTSyFHzEVj9l4xdFhvRUyM+gASPc6Wfp7pZWlV5YnQ==", null, false, new DateTime(2020, 12, 18, 19, 42, 22, 217, DateTimeKind.Local).AddTicks(2380), "1308dbfb-b5d4-4868-9f02-5aa7a92955e2", false, "user" },
                    { "4251b32b-0e51-4021-a334-7cbef9ba653c", 0, "a87a403b-9356-4f9f-aab4-0d7f0ddf7d09", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEKJtkRE+Hstc1M9VDLcmdV4+Zvlkho0X+7DPcLgG/+VklE84ApzVuJH+liz3yA6FFQ==", null, false, new DateTime(2020, 12, 18, 19, 42, 22, 235, DateTimeKind.Local).AddTicks(4912), "5482e5ec-b827-4888-b244-e19cca005372", false, "admin" }
                });

            migrationBuilder.InsertData(
                table: "currencies",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "usd" },
                    { 2, "eur" }
                });

            migrationBuilder.InsertData(
                table: "accounts",
                columns: new[] { "id", "name", "user_id" },
                values: new object[,]
                {
                    { 1, "main", "a2dea8b4-79b4-4136-bafe-721b4078d0b0" },
                    { 2, "second", "a2dea8b4-79b4-4136-bafe-721b4078d0b0" },
                    { 3, "admin", "4251b32b-0e51-4021-a334-7cbef9ba653c" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { "4b465d67-5641-4dd6-bc15-30516b0e5b9a", "a2dea8b4-79b4-4136-bafe-721b4078d0b0" },
                    { "0d71f2e3-2af6-48ab-b6a7-145633ebb0a4", "4251b32b-0e51-4021-a334-7cbef9ba653c" }
                });

            migrationBuilder.InsertData(
                table: "commissions",
                columns: new[] { "id", "currency_id", "max_commission", "max_value", "min_commission", "operation_type", "rate", "type", "user_id", "value" },
                values: new object[,]
                {
                    { 11, 1, 0.0, 100.0, 0.0, 0, 0.0, 0, null, 1.0 },
                    { 12, 1, 0.0, 100.0, 0.0, 2, 0.0, 0, null, 1.0 },
                    { 13, 1, 0.0, 100.0, 0.0, 1, 0.0, 0, null, 1.0 },
                    { 41, 2, 10.0, 50.0, 0.5, 0, 0.10000000000000001, 1, null, 0.0 },
                    { 42, 2, 10.0, 50.0, 0.5, 2, 0.10000000000000001, 1, null, 0.0 },
                    { 43, 2, 10.0, 50.0, 0.5, 1, 0.10000000000000001, 1, null, 0.0 },
                    { 31, 2, 0.0, 100.0, 0.0, 0, 0.0, 0, "4251b32b-0e51-4021-a334-7cbef9ba653c", 1.0 }
                });

            migrationBuilder.InsertData(
                table: "wallets",
                columns: new[] { "id", "account_id", "currency_id", "value" },
                values: new object[,]
                {
                    { 1, 1, 1, 1000.0 },
                    { 2, 2, 2, 2000.0 },
                    { 3, 3, 1, 666.0 },
                    { 4, 3, 2, 1408.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_accounts_user_id",
                table: "accounts",
                column: "user_id");

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
                name: "IX_commissions_currency_id",
                table: "commissions",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "IX_commissions_user_id",
                table: "commissions",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_currencies_name",
                table: "currencies",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_operations_transfer_wallet_id",
                table: "operations",
                column: "transfer_wallet_id");

            migrationBuilder.CreateIndex(
                name: "IX_operations_wallet_id",
                table: "operations",
                column: "wallet_id");

            migrationBuilder.CreateIndex(
                name: "IX_wallets_account_id",
                table: "wallets",
                column: "account_id");

            migrationBuilder.CreateIndex(
                name: "IX_wallets_currency_id",
                table: "wallets",
                column: "currency_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                name: "commissions");

            migrationBuilder.DropTable(
                name: "operations");

            migrationBuilder.DropTable(
                name: "asp_net_roles");

            migrationBuilder.DropTable(
                name: "wallets");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "currencies");

            migrationBuilder.DropTable(
                name: "asp_net_users");
        }
    }
}
