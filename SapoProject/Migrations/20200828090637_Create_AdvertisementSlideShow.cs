using Microsoft.EntityFrameworkCore.Migrations;

namespace SapoProject.Migrations
{
    public partial class Create_AdvertisementSlideShow : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AdvertisementSlideShow",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AdvertisementName = table.Column<string>(nullable: false),
                    AdvertisementShortDescription = table.Column<string>(nullable: false),
                    AdvertisementLongDescription = table.Column<string>(nullable: false),
                    AdvertisementImageUrl = table.Column<string>(nullable: false),
                    AdvertisementDestination = table.Column<string>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdvertisementSlideShow", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdvertisementSlideShow");
        }
    }
}
