using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomProject.Migrations
{
    public partial class OrderDropCountry : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Countries_CountryId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CountryId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Orders");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryId",
                table: "Orders",
                type: "nvarchar(2)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CountryId",
                table: "Orders",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Countries_CountryId",
                table: "Orders",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
