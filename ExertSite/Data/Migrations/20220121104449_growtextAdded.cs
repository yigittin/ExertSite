using Microsoft.EntityFrameworkCore.Migrations;

namespace ExertSite.Data.Migrations
{
    public partial class growtextAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ContactId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContactText = table.Column<string>(nullable: true),
                    AddressText = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    EMail = table.Column<string>(nullable: true),
                    ContactSmallText = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ContactId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");
        }
    }
}
