using Microsoft.EntityFrameworkCore.Migrations;

namespace Wallet.Migrations
{
    public partial class DepositColumnRename : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_commissions_stack_commissions_in_commission_id",
                table: "commissions_stack");

            migrationBuilder.RenameColumn(
                name: "in_commission_id",
                table: "commissions_stack",
                newName: "deposit_commission_id");

            migrationBuilder.RenameIndex(
                name: "IX_commissions_stack_in_commission_id",
                table: "commissions_stack",
                newName: "IX_commissions_stack_deposit_commission_id");

            migrationBuilder.AddForeignKey(
                name: "fk_commissions_stack_commissions_deposit_commission_id",
                table: "commissions_stack",
                column: "deposit_commission_id",
                principalTable: "commissions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_commissions_stack_commissions_deposit_commission_id",
                table: "commissions_stack");

            migrationBuilder.RenameColumn(
                name: "deposit_commission_id",
                table: "commissions_stack",
                newName: "in_commission_id");

            migrationBuilder.RenameIndex(
                name: "IX_commissions_stack_deposit_commission_id",
                table: "commissions_stack",
                newName: "IX_commissions_stack_in_commission_id");

            migrationBuilder.AddForeignKey(
                name: "fk_commissions_stack_commissions_in_commission_id",
                table: "commissions_stack",
                column: "in_commission_id",
                principalTable: "commissions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
