using Microsoft.EntityFrameworkCore.Migrations;

namespace SapoProject.Migrations
{
    public partial class update_test_authorization_User_with_Product : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusProduct",
                table: "User",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StatusProduct",
                table: "User");
        }
    }
}
