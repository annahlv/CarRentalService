using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomProject.Migrations
{
    public partial class _113 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Countries_SelectedCountryCode",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStates_StateId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SelectedCountryCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Cars");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "SelectedCountryCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "ZipCode",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "Orders",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cars",
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "AspNetUsers",
                maxLength: 30,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStates_StateId",
                table: "Orders",
                column: "StateId",
                principalTable: "OrderStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_OrderStates_StateId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<int>(
                name: "StateId",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 40);

            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Cars",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "City",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelectedCountryCode",
                table: "AspNetUsers",
                type: "nvarchar(2)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ZipCode",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Code = table.Column<string>(type: "nvarchar(2)", maxLength: 2, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Code);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_SelectedCountryCode",
                table: "AspNetUsers",
                column: "SelectedCountryCode");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Countries_SelectedCountryCode",
                table: "AspNetUsers",
                column: "SelectedCountryCode",
                principalTable: "Countries",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_OrderStates_StateId",
                table: "Orders",
                column: "StateId",
                principalTable: "OrderStates",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
