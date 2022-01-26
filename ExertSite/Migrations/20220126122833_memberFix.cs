using Microsoft.EntityFrameworkCore.Migrations;

namespace ExertSite.Migrations
{
    public partial class memberFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MemberSmallText",
                table: "Members");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MemberSmallText",
                table: "Members",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
