using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomProject.Migrations
{
    public partial class Zipcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Zip",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "Customers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "Customers");

            migrationBuilder.AddColumn<string>(
                name: "Zip",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
