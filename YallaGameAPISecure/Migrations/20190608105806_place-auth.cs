using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YallaGameAPISecure.Migrations
{
    public partial class placeauth : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConfirmPassword",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Place");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Place",
                nullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Place",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Place");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Place");

            migrationBuilder.AddColumn<string>(
                name: "ConfirmPassword",
                table: "Place",
                unicode: false,
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Place",
                unicode: false,
                maxLength: 50,
                nullable: true);
        }
    }
}
