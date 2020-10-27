using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomProject.Migrations
{
    public partial class _111 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Shipped",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "Cars");

            migrationBuilder.AddColumn<int>(
                name: "FuelVolume",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "Year",
                table: "Cars",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FuelVolume",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Year",
                table: "Cars");

            migrationBuilder.AddColumn<bool>(
                name: "Shipped",
                table: "Orders",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<decimal>(
                name: "Duration",
                table: "Cars",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
