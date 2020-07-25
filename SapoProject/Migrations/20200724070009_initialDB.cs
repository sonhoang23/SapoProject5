using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SapoProject.Migrations
{
    public partial class initialDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProductName = table.Column<string>(maxLength: 50, nullable: false),
                    Price = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    OriginalPrice = table.Column<string>(type: "varchar", maxLength: 50, nullable: false),
                    ShortDescription = table.Column<string>(nullable: false),
                    EntireDescription = table.Column<string>(nullable: false),
                    ViewCount = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    FixedDate = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(maxLength: 50, nullable: false),
                    PhoneNumber = table.Column<string>(type: "varchar", maxLength: 20, nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    Age = table.Column<int>(nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    EmailReset = table.Column<string>(maxLength: 50, nullable: false),
                    UserAccount = table.Column<string>(maxLength: 50, nullable: false),
                    UserPassWord = table.Column<string>(maxLength: 50, nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
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
