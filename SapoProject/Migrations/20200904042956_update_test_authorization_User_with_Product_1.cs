using Microsoft.EntityFrameworkCore.Migrations;

namespace SapoProject.Migrations
{
    public partial class update_test_authorization_User_with_Product_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "User");

            migrationBuilder.DropColumn(
                name: "StatusProduct",
                table: "User");

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "Product",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusProduct",
                table: "Product",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OwnerID",
                table: "Product");

            migrationBuilder.DropColumn(
                name: "StatusProduct",
                table: "Product");

            migrationBuilder.AddColumn<string>(
                name: "OwnerID",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusProduct",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
