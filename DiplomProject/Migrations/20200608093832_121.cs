using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomProject.Migrations
{
    public partial class _121 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxTorque",
                table: "Cars");

            migrationBuilder.AlterColumn<double>(
                name: "FuelVolume",
                table: "Cars",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "FuelVolume",
                table: "Cars",
                type: "int",
                nullable: false,
                oldClrType: typeof(double));

            migrationBuilder.AddColumn<int>(
                name: "MaxTorque",
                table: "Cars",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
