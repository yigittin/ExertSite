using Microsoft.EntityFrameworkCore.Migrations;

namespace ExertSite.Data.Migrations
{
    public partial class growImage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GrowText",
                columns: table => new
                {
                    GrowTextId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GrowtextImage = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrowText", x => x.GrowTextId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrowText");
        }
    }
}
