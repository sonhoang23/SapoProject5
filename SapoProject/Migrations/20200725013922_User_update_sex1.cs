using Microsoft.EntityFrameworkCore.Migrations;

namespace SapoProject.Migrations
{
    public partial class User_update_sex1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sex",
                table: "User");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sex",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
