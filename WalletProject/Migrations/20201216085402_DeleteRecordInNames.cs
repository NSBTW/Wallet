using Microsoft.EntityFrameworkCore.Migrations;

namespace Wallet.Migrations
{
    public partial class DeleteRecordInNames : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "fk_operations_wallets_target_wallet_record_id",
                table: "operations");

            migrationBuilder.DropForeignKey(
                name: "fk_operations_wallets_wallet_record_id",
                table: "operations");

            migrationBuilder.DropColumn(
                name: "is_user_commission",
                table: "commissions");

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
                table: "commissions",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "currency_record_id",
                table: "commissions",
                newName: "currency_id");

            migrationBuilder.RenameIndex(
                name: "IX_commissions_user_record_id",
                table: "commissions",
                newName: "IX_commissions_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_commissions_currency_record_id",
                table: "commissions",
                newName: "IX_commissions_currency_id");

            migrationBuilder.RenameColumn(
                name: "user_record_id",
                table: "accounts",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_user_record_id",
                table: "accounts",
                newName: "IX_accounts_user_id");

            migrationBuilder.AddForeignKey(
                name: "fk_accounts_asp_net_users_user_id",
                table: "accounts",
                column: "user_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_commissions_asp_net_users_user_id",
                table: "commissions",
                column: "user_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_commissions_currencies_currency_id",
                table: "commissions",
                column: "currency_id",
                principalTable: "currencies",
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_accounts_asp_net_users_user_id",
                table: "accounts");

            migrationBuilder.DropForeignKey(
                name: "fk_commissions_asp_net_users_user_id",
                table: "commissions");

            migrationBuilder.DropForeignKey(
                name: "fk_commissions_currencies_currency_id",
                table: "commissions");

            migrationBuilder.DropForeignKey(
                name: "fk_operations_wallets_target_wallet_id",
                table: "operations");

            migrationBuilder.DropForeignKey(
                name: "fk_operations_wallets_wallet_id",
                table: "operations");

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
                table: "commissions",
                newName: "user_record_id");

            migrationBuilder.RenameColumn(
                name: "currency_id",
                table: "commissions",
                newName: "currency_record_id");

            migrationBuilder.RenameIndex(
                name: "IX_commissions_user_id",
                table: "commissions",
                newName: "IX_commissions_user_record_id");

            migrationBuilder.RenameIndex(
                name: "IX_commissions_currency_id",
                table: "commissions",
                newName: "IX_commissions_currency_record_id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "accounts",
                newName: "user_record_id");

            migrationBuilder.RenameIndex(
                name: "IX_accounts_user_id",
                table: "accounts",
                newName: "IX_accounts_user_record_id");

            migrationBuilder.AddColumn<bool>(
                name: "is_user_commission",
                table: "commissions",
                type: "boolean",
                nullable: false,
                defaultValue: false);

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
        }
    }
}
