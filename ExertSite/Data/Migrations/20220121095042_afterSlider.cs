using Microsoft.EntityFrameworkCore.Migrations;

namespace ExertSite.Data.Migrations
{
    public partial class afterSlider : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ServiceText",
                table: "Services",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemberFacebook",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemberLinkedin",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemberSmallText",
                table: "Members",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MemberTwitter",
                table: "Members",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ServiceText",
                table: "Services");

            migrationBuilder.DropColumn(
                name: "MemberFacebook",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MemberLinkedin",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MemberSmallText",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "MemberTwitter",
                table: "Members");
        }
    }
}
