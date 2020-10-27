using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomProject.Migrations
{
    public partial class CarProperties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Users",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Fuel",
                table: "Cars",
                nullable: true,
                oldClrType: typeof(double),
                oldType: "float",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BootVolume",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Doors",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Drive",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "EngineSize",
                table: "Cars",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailable",
                table: "Cars",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxTorque",
                table: "Cars",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Seats",
                table: "Cars",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BootVolume",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Doors",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Drive",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "EngineSize",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "IsAvailable",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "MaxTorque",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Seats",
                table: "Cars");

            migrationBuilder.AlterColumn<string>(
                name: "Surname",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Users",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "Users",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<double>(
                name: "Fuel",
                table: "Cars",
                type: "float",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);
        }
    }
}
