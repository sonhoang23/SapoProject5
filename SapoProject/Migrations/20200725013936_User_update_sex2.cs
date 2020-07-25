using Microsoft.EntityFrameworkCore.Migrations;

namespace SapoProject.Migrations
{
    public partial class User_update_sex2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "User",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "User");
        }
    }
}
