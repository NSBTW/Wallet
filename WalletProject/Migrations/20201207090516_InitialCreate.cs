using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Wallet.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "commissions",
                columns: table => new
                {
                    commission_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    commission = table.Column<double>(type: "double precision", nullable: true),
                    rate = table.Column<double>(type: "double precision", nullable: true),
                    minimal_commission = table.Column<double>(type: "double precision", nullable: true),
                    maximal_commission = table.Column<double>(type: "double precision", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_commissions", x => x.commission_id);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    login = table.Column<string>(type: "text", nullable: true),
                    type = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_users", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "currencies",
                columns: table => new
                {
                    currency_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    commission_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_currencies", x => x.currency_id);
                    table.ForeignKey(
                        name: "fk_currencies_commissions_commission_id",
                        column: x => x.commission_id,
                        principalTable: "commissions",
                        principalColumn: "commission_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "accounts",
                columns: table => new
                {
                    account_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_accounts", x => x.account_id);
                    table.ForeignKey(
                        name: "fk_accounts_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "personal_commission",
                columns: table => new
                {
                    personal_commission_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    user_id = table.Column<int>(type: "integer", nullable: true),
                    currency_id = table.Column<int>(type: "integer", nullable: true),
                    commission_id = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_personal_commission", x => x.personal_commission_id);
                    table.ForeignKey(
                        name: "fk_personal_commission_commissions_commission_id",
                        column: x => x.commission_id,
                        principalTable: "commissions",
                        principalColumn: "commission_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_personal_commission_currencies_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currencies",
                        principalColumn: "currency_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_personal_commission_users_user_id",
                        column: x => x.user_id,
                        principalTable: "users",
                        principalColumn: "user_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "wallets",
                columns: table => new
                {
                    wallet_id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    account_id = table.Column<int>(type: "integer", nullable: true),
                    currency_id = table.Column<int>(type: "integer", nullable: true),
                    value = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_wallets", x => x.wallet_id);
                    table.ForeignKey(
                        name: "fk_wallets_accounts_account_id",
                        column: x => x.account_id,
                        principalTable: "accounts",
                        principalColumn: "account_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_wallets_currencies_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currencies",
                        principalColumn: "currency_id",
                        onDelete: ReferentialAction.Restrict);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_accounts_user_id",
                table: "accounts",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_currencies_commission_id",
                table: "currencies",
                column: "commission_id");

            migrationBuilder.CreateIndex(
                name: "IX_personal_commission_commission_id",
                table: "personal_commission",
                column: "commission_id");

            migrationBuilder.CreateIndex(
                name: "IX_personal_commission_currency_id",
                table: "personal_commission",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "IX_personal_commission_user_id",
                table: "personal_commission",
                column: "user_id");

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
                name: "personal_commission");

            migrationBuilder.DropTable(
                name: "wallets");

            migrationBuilder.DropTable(
                name: "accounts");

            migrationBuilder.DropTable(
                name: "currencies");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "commissions");
        }
    }
}
