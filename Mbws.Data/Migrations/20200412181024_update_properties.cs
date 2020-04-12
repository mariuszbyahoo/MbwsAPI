using Microsoft.EntityFrameworkCore.Migrations;

namespace Mbws.Data.Migrations
{
    public partial class update_properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Posts",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Posts",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Posts");
        }
    }
}
