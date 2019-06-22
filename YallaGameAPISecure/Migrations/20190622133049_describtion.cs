using Microsoft.EntityFrameworkCore.Migrations;

namespace YallaGameAPISecure.Migrations
{
    public partial class describtion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Place",
                unicode: false,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Place");
        }
    }
}
