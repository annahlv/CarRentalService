using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomProject.Migrations
{
    public partial class SomeLists : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CountryId",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "EndRent",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "StartRent",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SelectedCountryCode",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Countries",
                columns: table => new
                {
                    Code = table.Column<string>(maxLength: 2, nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Countries", x => x.Code);
                });

            migrationBuilder.CreateTable(
                name: "OrderStates",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderStates", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CountryId",
                table: "Orders",
                column: "CountryId");

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
                name: "FK_Orders_Countries_CountryId",
                table: "Orders",
                column: "CountryId",
                principalTable: "Countries",
                principalColumn: "Code",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Countries_SelectedCountryCode",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Countries_CountryId",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "OrderStates");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CountryId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_SelectedCountryCode",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "EndRent",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "StartRent",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SelectedCountryCode",
                table: "AspNetUsers");
        }
    }
}
