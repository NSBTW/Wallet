using Microsoft.EntityFrameworkCore.Migrations;

namespace Wallet.Migrations
{
    public partial class MoveMaxOperationValueToCommissionRecord : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "max_deposit",
                table: "currencies");

            migrationBuilder.DropColumn(
                name: "max_transfer",
                table: "currencies");

            migrationBuilder.DropColumn(
                name: "max_withdrawal",
                table: "currencies");

            migrationBuilder.RenameColumn(
                name: "min_value",
                table: "commissions",
                newName: "min_commission");

            migrationBuilder.AddColumn<double>(
                name: "max_commission",
                table: "commissions",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "max_commission",
                table: "commissions");

            migrationBuilder.RenameColumn(
                name: "min_commission",
                table: "commissions",
                newName: "min_value");

            migrationBuilder.AddColumn<double>(
                name: "max_deposit",
                table: "currencies",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "max_transfer",
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
    }
}
