using Microsoft.EntityFrameworkCore.Migrations;

namespace Wallet.Migrations
{
    public partial class refactorOperations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_operations_commissions_commission_record_id",
                table: "operations");

            migrationBuilder.DropIndex(
                name: "IX_operations_commission_record_id",
                table: "operations");

            migrationBuilder.DropColumn(
                name: "commission_record_id",
                table: "operations");

            migrationBuilder.RenameColumn(
                name: "case",
                table: "commissions",
                newName: "operation_type");

            migrationBuilder.AddColumn<double>(
                name: "max_deposit",
                table: "currencies",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "max_withdrawal",
                table: "currencies",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "max_deposit",
                table: "currencies");

            migrationBuilder.DropColumn(
                name: "max_withdrawal",
                table: "currencies");

            migrationBuilder.RenameColumn(
                name: "operation_type",
                table: "commissions",
                newName: "case");

            migrationBuilder.AddColumn<string>(
                name: "commission_record_id",
                table: "operations",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_operations_commission_record_id",
                table: "operations",
                column: "commission_record_id");

            migrationBuilder.AddForeignKey(
                name: "fk_operations_commissions_commission_record_id",
                table: "operations",
                column: "commission_record_id",
                principalTable: "commissions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
