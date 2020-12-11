using Microsoft.EntityFrameworkCore.Migrations;

namespace Wallet.Migrations
{
    public partial class CommissionsStack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropPrimaryKey(
                name: "pk_personal_commission",
                table: "personal_commission");

            migrationBuilder.RenameTable(
                name: "personal_commission",
                newName: "personal_commissions");

            migrationBuilder.RenameColumn(
                name: "commission_id",
                table: "currencies",
                newName: "commissions_stack_id");

            migrationBuilder.RenameIndex(
                name: "IX_currencies_commission_id",
                table: "currencies",
                newName: "IX_currencies_commissions_stack_id");

            migrationBuilder.RenameColumn(
                name: "commission_id",
                table: "personal_commissions",
                newName: "commissions_stack_id");

            migrationBuilder.RenameIndex(
                name: "IX_personal_commission_user_id",
                table: "personal_commissions",
                newName: "IX_personal_commissions_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_personal_commission_currency_id",
                table: "personal_commissions",
                newName: "IX_personal_commissions_currency_id");

            migrationBuilder.RenameIndex(
                name: "IX_personal_commission_commission_id",
                table: "personal_commissions",
                newName: "IX_personal_commissions_commissions_stack_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_personal_commissions",
                table: "personal_commissions",
                column: "id");

            migrationBuilder.CreateTable(
                name: "commissions_stack",
                columns: table => new
                {
                    id = table.Column<string>(type: "text", nullable: false),
                    transfer_commission_id = table.Column<string>(type: "text", nullable: true),
                    in_commission_id = table.Column<string>(type: "text", nullable: true),
                    out_commission_id = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_commissions_stack", x => x.id);
                    table.ForeignKey(
                        name: "fk_commissions_stack_commissions_in_commission_id",
                        column: x => x.in_commission_id,
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

            migrationBuilder.CreateIndex(
                name: "IX_commissions_stack_in_commission_id",
                table: "commissions_stack",
                column: "in_commission_id");

            migrationBuilder.CreateIndex(
                name: "IX_commissions_stack_out_commission_id",
                table: "commissions_stack",
                column: "out_commission_id");

            migrationBuilder.CreateIndex(
                name: "IX_commissions_stack_transfer_commission_id",
                table: "commissions_stack",
                column: "transfer_commission_id");

            migrationBuilder.AddForeignKey(
                name: "fk_currencies_commissions_stack_commissions_stack_id",
                table: "currencies",
                column: "commissions_stack_id",
                principalTable: "commissions_stack",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_personal_commissions_asp_net_users_user_id",
                table: "personal_commissions",
                column: "user_id",
                principalTable: "asp_net_users",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_personal_commissions_commissions_stack_commissions_stack_id",
                table: "personal_commissions",
                column: "commissions_stack_id",
                principalTable: "commissions_stack",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_personal_commissions_currencies_currency_id",
                table: "personal_commissions",
                column: "currency_id",
                principalTable: "currencies",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_currencies_commissions_stack_commissions_stack_id",
                table: "currencies");

            migrationBuilder.DropForeignKey(
                name: "fk_personal_commissions_asp_net_users_user_id",
                table: "personal_commissions");

            migrationBuilder.DropForeignKey(
                name: "fk_personal_commissions_commissions_stack_commissions_stack_id",
                table: "personal_commissions");

            migrationBuilder.DropForeignKey(
                name: "fk_personal_commissions_currencies_currency_id",
                table: "personal_commissions");

            migrationBuilder.DropTable(
                name: "commissions_stack");

            migrationBuilder.DropPrimaryKey(
                name: "pk_personal_commissions",
                table: "personal_commissions");

            migrationBuilder.RenameTable(
                name: "personal_commissions",
                newName: "personal_commission");

            migrationBuilder.RenameColumn(
                name: "commissions_stack_id",
                table: "currencies",
                newName: "commission_id");

            migrationBuilder.RenameIndex(
                name: "IX_currencies_commissions_stack_id",
                table: "currencies",
                newName: "IX_currencies_commission_id");

            migrationBuilder.RenameColumn(
                name: "commissions_stack_id",
                table: "personal_commission",
                newName: "commission_id");

            migrationBuilder.RenameIndex(
                name: "IX_personal_commissions_user_id",
                table: "personal_commission",
                newName: "IX_personal_commission_user_id");

            migrationBuilder.RenameIndex(
                name: "IX_personal_commissions_currency_id",
                table: "personal_commission",
                newName: "IX_personal_commission_currency_id");

            migrationBuilder.RenameIndex(
                name: "IX_personal_commissions_commissions_stack_id",
                table: "personal_commission",
                newName: "IX_personal_commission_commission_id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_personal_commission",
                table: "personal_commission",
                column: "id");

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
        }
    }
}
