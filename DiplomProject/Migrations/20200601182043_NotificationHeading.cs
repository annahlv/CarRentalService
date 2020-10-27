using Microsoft.EntityFrameworkCore.Migrations;

namespace DiplomProject.Migrations
{
    public partial class NotificationHeading : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Heading",
                table: "Notifications",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Heading",
                table: "Notifications");
        }
    }
}
