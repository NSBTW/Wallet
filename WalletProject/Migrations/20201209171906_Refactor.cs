using Microsoft.EntityFrameworkCore.Migrations;

namespace Wallet.Migrations
{
    public partial class Refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_accounts_asp_net_users_user_id",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "fk_currencies_commissions_stack_commissions_stack_id",
                table: "currencies");

            migrationBuilder.DropForeignKey(
                name: "fk_operations_wallets_target_wallet_id",
                table: "operations");

            migrationBuilder.DropForeignKey(
                name: "fk_operations_wallets_wallet_id",
                table: "operations");

            migrationBuilder.DropForeignKey(
                name: "fk_wallets_accounts_account_id",
                table: "wallets");

            migrationBuilder.DropForeignKey(
                name: "fk_wallets_currencies_currency_id",
                table: "wallets");

            migrationBuilder.DropTable(
                name: "personal_commissions");

            migrationBuilder.DropTable(
                name: "commissions_stack");

            migrationBuilder.DropIndex(
                name: "IX_currencies_commissions_stack_id",
                table: "currencies");

            migrationBuilder.DropColumn(
                name: "discriminator",
                table: "operations");

            migrationBuilder.DropColumn(
                name: "commissions_stack_id",
                table: "currencies");

            migrationBuilder.DropColumn(
                name: "commission",
                table: "commissions");

            migrationBuilder.DropColumn(
                name: "discriminator",
                table: "commissions");

            migrationBuilder.DropColumn(
                name: "maximal_commission",
                table: "commissions");

            migrationBuilder.DropColumn(
                name: "minimal_commission",
                table: "commissions");

            migrationBuilder.RenameColumn(
                name: "currency_id",
                table: "wallets",
                newName: "currency_record_id");

            migrationBuilder.RenameColumn(
                name: "account_id",
                table: "wallets",
                newName: "account_record_id");

            migrationBuilder.RenameIndex(
                name: "IX_wallets_currency_id",
                table: "wallets",
                newName: "IX_wallets_currency_record_id");

            migrationBuilder.RenameIndex(
                name: "IX_wallets_account_id",
                table: "wallets",
                newName: "IX_wallets_account_record_id");

            migrationBuilder.RenameColumn(
                name: "wallet_id",
                table: "operations",
                newName: "wallet_record_id");

            migrationBuilder.RenameColumn(
                name: "target_wallet_id",
                table: "operations",
                newName: "target_wallet_record_id");

            migrationBuilder.RenameIndex(
                name: "IX_operations_wallet_id",
                table: "operations",
                newName: "IX_operations_wallet_record_id");

            migrationBuilder.RenameIndex(
                name: "IX_operations_target_wallet_id",
                table: "operations",
                newName: "IX_operations_target_wallet_record_id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "accounts",
                newName: "user_record_id");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_user_id",
                table: "accounts",
                newName: "IX_accounts_user_record_id");

            migrationBuilder.AddColumn<string>(
                name: "commission_record_id",
                table: "operations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "operations",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<double>(
                name: "rate",
                table: "commissions",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0,
                oldClrType: typeof(double),
                oldType: "double precision",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "case",
                table: "commissions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "currency_record_id",
                table: "commissions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "is_user_commission",
                table: "commissions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "max_value",
                table: "commissions",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "min_value",
                table: "commissions",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<int>(
                name: "type",
                table: "commissions",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "user_record_id",
                table: "commissions",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "value",
                table: "commissions",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.CreateIndex(
                name: "IX_operations_commission_record_id",
                table: "operations",
                column: "commission_record_id");

            migrationBuilder.CreateIndex(
                name: "IX_commissions_currency_record_id",
                table: "commissions",
                column: "currency_record_id");

            migrationBuilder.CreateIndex(
                name: "IX_commissions_user_record_id",
                table: "commissions",
                column: "user_record_id");

            migrationBuilder.AddForeignKey(
                name: "fk_accounts_asp_net_users_user_record_id",
                table: "accounts",
                column: "user_record_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_commissions_asp_net_users_user_record_id",
                table: "commissions",
                column: "user_record_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_commissions_currencies_currency_record_id",
                table: "commissions",
                column: "currency_record_id",
                principalTable: "currencies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_operations_commissions_commission_record_id",
                table: "operations",
                column: "commission_record_id",
                principalTable: "commissions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_operations_wallets_target_wallet_record_id",
                table: "operations",
                column: "target_wallet_record_id",
                principalTable: "wallets",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_operations_wallets_wallet_record_id",
                table: "operations",
                column: "wallet_record_id",
                principalTable: "wallets",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_wallets_accounts_account_record_id",
                table: "wallets",
                column: "account_record_id",
                principalTable: "accounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_wallets_currencies_currency_record_id",
                table: "wallets",
                column: "currency_record_id",
                principalTable: "currencies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_accounts_asp_net_users_user_record_id",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "fk_commissions_asp_net_users_user_record_id",
                table: "commissions");

            migrationBuilder.DropForeignKey(
                name: "fk_commissions_currencies_currency_record_id",
                table: "commissions");

            migrationBuilder.DropForeignKey(
                name: "fk_operations_commissions_commission_record_id",
                table: "operations");

            migrationBuilder.DropForeignKey(
                name: "fk_operations_wallets_target_wallet_record_id",
                table: "operations");

            migrationBuilder.DropForeignKey(
                name: "fk_operations_wallets_wallet_record_id",
                table: "operations");

            migrationBuilder.DropForeignKey(
                name: "fk_wallets_accounts_account_record_id",
                table: "wallets");

            migrationBuilder.DropForeignKey(
                name: "fk_wallets_currencies_currency_record_id",
                table: "wallets");

            migrationBuilder.DropIndex(
                name: "IX_operations_commission_record_id",
                table: "operations");

            migrationBuilder.DropIndex(
                name: "IX_commissions_currency_record_id",
                table: "commissions");

            migrationBuilder.DropIndex(
                name: "IX_commissions_user_record_id",
                table: "commissions");

            migrationBuilder.DropColumn(
                name: "commission_record_id",
                table: "operations");

            migrationBuilder.DropColumn(
                name: "type",
                table: "operations");

            migrationBuilder.DropColumn(
                name: "case",
                table: "commissions");

            migrationBuilder.DropColumn(
                name: "currency_record_id",
                table: "commissions");

            migrationBuilder.DropColumn(
                name: "is_user_commission",
                table: "commissions");

            migrationBuilder.DropColumn(
                name: "max_value",
                table: "commissions");

            migrationBuilder.DropColumn(
                name: "min_value",
                table: "commissions");

            migrationBuilder.DropColumn(
                name: "type",
                table: "commissions");

            migrationBuilder.DropColumn(
                name: "user_record_id",
                table: "commissions");

            migrationBuilder.DropColumn(
                name: "value",
                table: "commissions");

            migrationBuilder.RenameColumn(
                name: "currency_record_id",
                table: "wallets",
                newName: "currency_id");

            migrationBuilder.RenameColumn(
                name: "account_record_id",
                table: "wallets",
                newName: "account_id");

            migrationBuilder.RenameIndex(
                name: "IX_wallets_currency_record_id",
                table: "wallets",
                newName: "IX_wallets_currency_id");

            migrationBuilder.RenameIndex(
                name: "IX_wallets_account_record_id",
                table: "wallets",
                newName: "IX_wallets_account_id");

            migrationBuilder.RenameColumn(
                name: "wallet_record_id",
                table: "operations",
                newName: "wallet_id");

            migrationBuilder.RenameColumn(
                name: "target_wallet_record_id",
                table: "operations",
                newName: "target_wallet_id");

            migrationBuilder.RenameIndex(
                name: "IX_operations_wallet_record_id",
                table: "operations",
                newName: "IX_operations_wallet_id");

            migrationBuilder.RenameIndex(
                name: "IX_operations_target_wallet_record_id",
                table: "operations",
                newName: "IX_operations_target_wallet_id");

            migrationBuilder.RenameColumn(
                name: "user_record_id",
                table: "accounts",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_user_record_id",
                table: "accounts",
                newName: "IX_accounts_user_id");

            migrationBuilder.AddColumn<string>(
                name: "discriminator",
                table: "operations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "commissions_stack_id",
                table: "currencies",
                type: "text",
                nullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "rate",
                table: "commissions",
                type: "double precision",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "double precision");

            migrationBuilder.AddColumn<double>(
                name: "commission",
                table: "commissions",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "discriminator",
                table: "commissions",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<double>(
                name: "maximal_commission",
                table: "commissions",
                type: "double precision",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "minimal_commission",
                table: "commissions",
                type: "double precision",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "commissions_stack",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    deposit_commission_id = table.Column<string>(type: "text", nullable: true),
                    out_commission_id = table.Column<string>(type: "text", nullable: true),
                    transfer_commission_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_commissions_stack", x => x.id);
                    table.ForeignKey(
                        name: "fk_commissions_stack_commissions_deposit_commission_id",
                        column: x => x.deposit_commission_id,
                        principalTable: "commissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commissions_stack_commissions_out_commission_id",
                        column: x => x.out_commission_id,
                        principalTable: "commissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_commissions_stack_commissions_transfer_commission_id",
                        column: x => x.transfer_commission_id,
                        principalTable: "commissions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "personal_commissions",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    commissions_stack_id = table.Column<string>(type: "text", nullable: true),
                    currency_id = table.Column<string>(type: "text", nullable: true),
                    user_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_personal_commissions", x => x.id);
                    table.ForeignKey(
                        name: "fk_personal_commissions_asp_net_users_user_id",
                        column: x => x.user_id,
                        principalTable: "asp_net_users",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_personal_commissions_commissions_stack_commissions_stack_id",
                        column: x => x.commissions_stack_id,
                        principalTable: "commissions_stack",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_personal_commissions_currencies_currency_id",
                        column: x => x.currency_id,
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_currencies_commissions_stack_id",
                table: "currencies",
                column: "commissions_stack_id");

            migrationBuilder.CreateIndex(
                name: "IX_commissions_stack_deposit_commission_id",
                table: "commissions_stack",
                column: "deposit_commission_id");

            migrationBuilder.CreateIndex(
                name: "IX_commissions_stack_out_commission_id",
                table: "commissions_stack",
                column: "out_commission_id");

            migrationBuilder.CreateIndex(
                name: "IX_commissions_stack_transfer_commission_id",
                table: "commissions_stack",
                column: "transfer_commission_id");

            migrationBuilder.CreateIndex(
                name: "IX_personal_commissions_commissions_stack_id",
                table: "personal_commissions",
                column: "commissions_stack_id");

            migrationBuilder.CreateIndex(
                name: "IX_personal_commissions_currency_id",
                table: "personal_commissions",
                column: "currency_id");

            migrationBuilder.CreateIndex(
                name: "IX_personal_commissions_user_id",
                table: "personal_commissions",
                column: "user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_accounts_asp_net_users_user_id",
                table: "accounts",
                column: "user_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_currencies_commissions_stack_commissions_stack_id",
                table: "currencies",
                column: "commissions_stack_id",
                principalTable: "commissions_stack",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_operations_wallets_target_wallet_id",
                table: "operations",
                column: "target_wallet_id",
                principalTable: "wallets",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_operations_wallets_wallet_id",
                table: "operations",
                column: "wallet_id",
                principalTable: "wallets",
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
    }
}
