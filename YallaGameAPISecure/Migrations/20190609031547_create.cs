using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace YallaGameAPISecure.Migrations
{
    public partial class create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Game_Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    Image = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Multi = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Game_Id);
                });

            migrationBuilder.CreateTable(
                name: "Place",
                columns: table => new
                {
                    Place_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Phone = table.Column<string>(unicode: false, maxLength: 20, nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    Country = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    City = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Rate = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Image = table.Column<string>(unicode: false, maxLength: 500, nullable: true),
                    Days = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Location = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    OpenHour = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CloseHour = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    EmailKey = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Place", x => x.Place_Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    User_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Phone = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    PasswordSalt = table.Column<byte[]>(nullable: true),
                    PasswordHash = table.Column<byte[]>(nullable: true),
                    Country = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    City = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    CurrentCity = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Email = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Image = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    EmailKey = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Online = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.User_Id);
                });

            migrationBuilder.CreateTable(
                name: "GameInPlace",
                columns: table => new
                {
                    Game_Id = table.Column<int>(nullable: false),
                    Place_Id = table.Column<int>(nullable: false),
                    Rate = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameInPlace", x => new { x.Game_Id, x.Place_Id });
                    table.ForeignKey(
                        name: "FK_GameInPlace_Game",
                        column: x => x.Game_Id,
                        principalTable: "Game",
                        principalColumn: "Game_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameInPlace_Place",
                        column: x => x.Place_Id,
                        principalTable: "Place",
                        principalColumn: "Place_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ImageOfPlace",
                columns: table => new
                {
                    Place_Id = table.Column<int>(nullable: false),
                    ImageOfPlace_Id = table.Column<int>(nullable: false),
                    Name = table.Column<string>(unicode: false, maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImageOfPlace", x => new { x.Place_Id, x.ImageOfPlace_Id });
                    table.ForeignKey(
                        name: "FK_ImageOfPlace_Place",
                        column: x => x.Place_Id,
                        principalTable: "Place",
                        principalColumn: "Place_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review_place",
                columns: table => new
                {
                    Place_Id = table.Column<int>(nullable: true),
                    User_Id = table.Column<int>(nullable: true),
                    Review_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    content = table.Column<string>(unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review_place", x => x.Review_Id);
                    table.ForeignKey(
                        name: "FK_Review_place_Place",
                        column: x => x.Place_Id,
                        principalTable: "Place",
                        principalColumn: "Place_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Chat",
                columns: table => new
                {
                    Chat_Id = table.Column<int>(nullable: false),
                    Sender_Id = table.Column<int>(nullable: false),
                    Receiver_Id = table.Column<int>(nullable: false),
                    Date = table.Column<DateTime>(type: "date", nullable: true),
                    Description = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Chat", x => x.Chat_Id);
                    table.ForeignKey(
                        name: "FK_Chat_User1",
                        column: x => x.Receiver_Id,
                        principalTable: "User",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Chat_User",
                        column: x => x.Sender_Id,
                        principalTable: "User",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GameByUser",
                columns: table => new
                {
                    Game_Id = table.Column<int>(nullable: false),
                    User_Id = table.Column<int>(nullable: false),
                    Score = table.Column<int>(nullable: true),
                    Allgames = table.Column<string>(unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GameByUser", x => new { x.Game_Id, x.User_Id });
                    table.ForeignKey(
                        name: "FK_GameByUser_Game",
                        column: x => x.Game_Id,
                        principalTable: "Game",
                        principalColumn: "Game_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GameByUser_User",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Group_Chat",
                columns: table => new
                {
                    Group_Id = table.Column<int>(nullable: false),
                    Sender_Id = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group_Chat", x => x.Group_Id);
                    table.ForeignKey(
                        name: "FK_Group_Chat_User",
                        column: x => x.Sender_Id,
                        principalTable: "User",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Invitation",
                columns: table => new
                {
                    Invitation_Id = table.Column<int>(nullable: false),
                    Sender_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invitation", x => x.Invitation_Id);
                    table.ForeignKey(
                        name: "FK_Invitation_User",
                        column: x => x.Sender_Id,
                        principalTable: "User",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Online_Users",
                columns: table => new
                {
                    User_Id = table.Column<int>(nullable: true),
                    Lang = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Lat = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    Online_Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Online_Users", x => x.Online_Id);
                    table.ForeignKey(
                        name: "FK_Online_Users_User",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Review_User",
                columns: table => new
                {
                    Review_Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    User_Id = table.Column<int>(nullable: true),
                    Reviewer_Id = table.Column<int>(nullable: true),
                    content = table.Column<string>(unicode: false, maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Review_User", x => x.Review_Id);
                    table.ForeignKey(
                        name: "FK_Review_User_User1",
                        column: x => x.Reviewer_Id,
                        principalTable: "User",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Review_User_User",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserInvitation",
                columns: table => new
                {
                    Invitation_Id = table.Column<int>(nullable: false),
                    User_Id = table.Column<int>(nullable: false),
                    Accept = table.Column<bool>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserInvitation", x => new { x.Invitation_Id, x.User_Id });
                    table.ForeignKey(
                        name: "FK_UserInvitation_Invitation",
                        column: x => x.Invitation_Id,
                        principalTable: "Invitation",
                        principalColumn: "Invitation_Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserInvitation_User",
                        column: x => x.User_Id,
                        principalTable: "User",
                        principalColumn: "User_Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Chat_Receiver_Id",
                table: "Chat",
                column: "Receiver_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Chat_Sender_Id",
                table: "Chat",
                column: "Sender_Id");

            migrationBuilder.CreateIndex(
                name: "IX_GameByUser_User_Id",
                table: "GameByUser",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_GameInPlace_Place_Id",
                table: "GameInPlace",
                column: "Place_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Group_Chat_Sender_Id",
                table: "Group_Chat",
                column: "Sender_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Invitation_Sender_Id",
                table: "Invitation",
                column: "Sender_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Online_Users_User_Id",
                table: "Online_Users",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_place_Place_Id",
                table: "Review_place",
                column: "Place_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_User_Reviewer_Id",
                table: "Review_User",
                column: "Reviewer_Id");

            migrationBuilder.CreateIndex(
                name: "IX_Review_User_User_Id",
                table: "Review_User",
                column: "User_Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserInvitation_User_Id",
                table: "UserInvitation",
                column: "User_Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Chat");

            migrationBuilder.DropTable(
                name: "GameByUser");

            migrationBuilder.DropTable(
                name: "GameInPlace");

            migrationBuilder.DropTable(
                name: "Group_Chat");

            migrationBuilder.DropTable(
                name: "ImageOfPlace");

            migrationBuilder.DropTable(
                name: "Online_Users");

            migrationBuilder.DropTable(
                name: "Review_place");

            migrationBuilder.DropTable(
                name: "Review_User");

            migrationBuilder.DropTable(
                name: "UserInvitation");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropTable(
                name: "Place");

            migrationBuilder.DropTable(
                name: "Invitation");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
