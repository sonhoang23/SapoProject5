using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SapoProject.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    productName = table.Column<string>(nullable: true),
                    Price = table.Column<string>(nullable: true),
                    OriginalPrice = table.Column<string>(nullable: true),
                    shortDescription = table.Column<string>(nullable: true),
                    entireDescription = table.Column<string>(nullable: true),
                    ViewCount = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    age = table.Column<int>(nullable: false),
                    email = table.Column<string>(nullable: true),
                    emailReset = table.Column<string>(nullable: true),
                    userAccount = table.Column<string>(nullable: true),
                    userPassWord = table.Column<string>(nullable: true),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "WebInfor",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InforName = table.Column<string>(nullable: true),
                    shortDescription = table.Column<string>(nullable: true),
                    entireDescription = table.Column<string>(nullable: true),
                    phoneNumber = table.Column<string>(nullable: true),
                    address = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    ViewCount = table.Column<int>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WebInfor", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "WebInfor");
        }
    }
}
