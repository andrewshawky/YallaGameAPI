using Microsoft.EntityFrameworkCore.Migrations;

namespace YallaGameAPISecure.Migrations
{
    public partial class placelocation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Place");

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Place",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Place",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Place");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Place",
                unicode: false,
                maxLength: 100,
                nullable: true);
        }
    }
}
