using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomProject.Migrations
{
    public partial class StateFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Orders",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_StateId",
                table: "Orders",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStates_StateId",
                table: "Orders",
                column: "StateId",
                principalTable: "OrderStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStates_StateId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_StateId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Orders");
        }
    }
}
