using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Wallet.Migrations
{
    public partial class refactor : Migration
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
                    registration_date = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
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
                        onDelete: ReferentialAction.Cascade);
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
                    created_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()"),
                    updated_at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false, defaultValueSql: "now()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_operations", x => x.id);
                    table.ForeignKey(
                        name: "fk_operations_wallets_transfer_wallet_id",
                        column: x => x.transfer_wallet_id,
                        principalTable: "wallets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    { "8f4327f9-16d1-4e55-803a-088a69548b14", "27bed53e-6c82-47c0-a2da-85c406288d5c", "admin", "ADMIN" },
                    { "abaea8d9-466a-4c83-9bc7-ad7067861f7a", "ae4a8567-a5d2-440e-8213-02fe835d1612", "user", "USER" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_users",
                columns: new[] { "id", "access_failed_count", "concurrency_stamp", "email", "email_confirmed", "lockout_enabled", "lockout_end", "normalized_email", "normalized_user_name", "password_hash", "phone_number", "phone_number_confirmed", "registration_date", "security_stamp", "two_factor_enabled", "user_name" },
                values: new object[,]
                {
                    { "ac56e83a-6aee-4969-8c7d-2e063a5ce013", 0, "c0f6fcd1-a123-4b69-a596-d22e09dbb09c", null, false, false, null, null, "USER", "AQAAAAEAACcQAAAAELZMjs6sqDHz9U211U2aUqt5ikGhrieDNKjgSbsh7Fhpqd6t9D2b0rKmopaTNJvu+A==", null, false, new DateTime(2020, 12, 20, 22, 59, 6, 359, DateTimeKind.Local).AddTicks(662), "78baaa41-e1b1-4d3e-9072-7cde48d008b0", false, "user" },
                    { "dce84adb-afb0-45d6-881a-f54823d48884", 0, "f77c21a9-46b9-480a-b365-308958991b5a", null, false, false, null, null, "ADMIN", "AQAAAAEAACcQAAAAEJIAAgJiM2M5VgcoPFPh3dfRqeL1ioeH90TkSrnPZim8D6isLD6E1HwdONAerKyH5w==", null, false, new DateTime(2020, 12, 20, 22, 59, 6, 392, DateTimeKind.Local).AddTicks(259), "218c0535-5996-4094-872a-7f533cdae658", false, "admin" }
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
                    { 1, "main", "ac56e83a-6aee-4969-8c7d-2e063a5ce013" },
                    { 2, "second", "ac56e83a-6aee-4969-8c7d-2e063a5ce013" },
                    { 3, "admin", "dce84adb-afb0-45d6-881a-f54823d48884" }
                });

            migrationBuilder.InsertData(
                table: "asp_net_user_roles",
                columns: new[] { "role_id", "user_id" },
                values: new object[,]
                {
                    { "abaea8d9-466a-4c83-9bc7-ad7067861f7a", "ac56e83a-6aee-4969-8c7d-2e063a5ce013" },
                    { "8f4327f9-16d1-4e55-803a-088a69548b14", "dce84adb-afb0-45d6-881a-f54823d48884" }
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
                    { 31, 2, 0.0, 100.0, 0.0, 0, 0.0, 0, "dce84adb-afb0-45d6-881a-f54823d48884", 1.0 }
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
