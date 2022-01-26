using Microsoft.EntityFrameworkCore.Migrations;

namespace ExertSite.Migrations
{
    public partial class memberFix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MemberWebsite",
                table: "Members",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberWebsite",
                table: "Members");
        }
    }
}
