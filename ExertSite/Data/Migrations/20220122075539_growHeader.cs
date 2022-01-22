using Microsoft.EntityFrameworkCore.Migrations;

namespace ExertSite.Data.Migrations
{
    public partial class growHeader : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "GrowHeader",
                table: "GrowText",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<string>(nullable: false),
                    ClientImage = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropColumn(
                name: "GrowHeader",
                table: "GrowText");
        }
    }
}
