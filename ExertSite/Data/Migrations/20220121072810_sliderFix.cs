using Microsoft.EntityFrameworkCore.Migrations;

namespace ExertSite.Data.Migrations
{
    public partial class sliderFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SliderDesc",
                table: "Sliders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SliderDesc",
                table: "Sliders");
        }
    }
}
