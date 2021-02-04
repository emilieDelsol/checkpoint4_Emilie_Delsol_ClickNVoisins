using Microsoft.EntityFrameworkCore.Migrations;

namespace clickAndV.Migrations
{
    public partial class addBannerOnCategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Banner",
                table: "Categories",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Banner",
                table: "Categories");
        }
    }
}
