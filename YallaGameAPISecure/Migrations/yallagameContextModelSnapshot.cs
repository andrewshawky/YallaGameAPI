﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using YallaGameAPISecure.Models;

namespace YallaGameAPISecure.Migrations
{
    [DbContext(typeof(yallagameContext))]
    partial class yallagameContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("YallaGameAPISecure.Models.Chat", b =>
                {
                    b.Property<int>("ChatId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Chat_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.Property<bool>("IsDeleted");

                    b.Property<int>("ReceiverId")
                        .HasColumnName("Receiver_Id");

                    b.Property<int>("SenderId")
                        .HasColumnName("Sender_Id");

                    b.HasKey("ChatId");

                    b.HasIndex("ReceiverId");

                    b.HasIndex("SenderId");

                    b.ToTable("Chat");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Game_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<string>("Image")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<bool?>("Multi");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("GameId");

                    b.ToTable("Game");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.GameByUser", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnName("Game_Id");

                    b.Property<int>("UserId")
                        .HasColumnName("User_Id");

                    b.Property<string>("Allgames")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<int?>("Score");

                    b.HasKey("GameId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("GameByUser");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.GameInPlace", b =>
                {
                    b.Property<int>("GameId")
                        .HasColumnName("Game_Id");

                    b.Property<int>("PlaceId")
                        .HasColumnName("Place_Id");

                    b.Property<string>("Rate")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("GameId", "PlaceId");

                    b.HasIndex("PlaceId");

                    b.ToTable("GameInPlace");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.GroupChat", b =>
                {
                    b.Property<int>("GroupId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Group_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("Date")
                        .HasColumnType("date");

                    b.Property<string>("Description");

                    b.Property<int>("SenderId")
                        .HasColumnName("Sender_Id");

                    b.HasKey("GroupId");

                    b.HasIndex("SenderId");

                    b.ToTable("Group_Chat");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.ImageOfPlace", b =>
                {
                    b.Property<int>("PlaceId")
                        .HasColumnName("Place_Id");

                    b.Property<int>("ImageOfPlaceId")
                        .HasColumnName("ImageOfPlace_Id");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("PlaceId", "ImageOfPlaceId");

                    b.ToTable("ImageOfPlace");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.Invitation", b =>
                {
                    b.Property<int>("InvitationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Invitation_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("SenderId")
                        .HasColumnName("Sender_Id");

                    b.HasKey("InvitationId");

                    b.HasIndex("SenderId");

                    b.ToTable("Invitation");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.OnlineUsers", b =>
                {
                    b.Property<int>("OnlineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Online_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Lang")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Lat")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("UserId")
                        .HasColumnName("User_Id");

                    b.HasKey("OnlineId");

                    b.HasIndex("UserId");

                    b.ToTable("Online_Users");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.Place", b =>
                {
                    b.Property<int>("PlaceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Place_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("CloseHour")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Country")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Days")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Description")
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<int?>("EmailKey");

                    b.Property<string>("Image")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<double>("Latitude");

                    b.Property<double>("Longitude");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("OpenHour")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .IsUnicode(false);

                    b.Property<string>("Rate")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("PlaceId");

                    b.ToTable("Place");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.ReviewPlace", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Review_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnName("content")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<int?>("PlaceId")
                        .HasColumnName("Place_Id");

                    b.Property<int>("Rate")
                        .HasColumnName("Rate");

                    b.Property<int?>("UserId")
                        .HasColumnName("User_Id");

                    b.HasKey("ReviewId");

                    b.HasIndex("PlaceId");

                    b.ToTable("Review_place");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.ReviewUser", b =>
                {
                    b.Property<int>("ReviewId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Review_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnName("content")
                        .HasMaxLength(500)
                        .IsUnicode(false);

                    b.Property<int>("Rate")
                        .HasColumnName("Rate");

                    b.Property<int?>("ReviewerId")
                        .HasColumnName("Reviewer_Id");

                    b.Property<int?>("UserId")
                        .HasColumnName("User_Id");

                    b.HasKey("ReviewId");

                    b.HasIndex("ReviewerId");

                    b.HasIndex("UserId");

                    b.ToTable("Review_User");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("User_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Country")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("CurrentCity")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("EmailKey")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Image")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.Property<bool?>("Online");

                    b.Property<byte[]>("PasswordHash");

                    b.Property<byte[]>("PasswordSalt");

                    b.Property<string>("Phone")
                        .HasMaxLength(100)
                        .IsUnicode(false);

                    b.HasKey("UserId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.UserInvitation", b =>
                {
                    b.Property<int>("InvitationId")
                        .HasColumnName("Invitation_Id");

                    b.Property<int>("UserId")
                        .HasColumnName("User_Id");

                    b.Property<bool?>("Accept");

                    b.HasKey("InvitationId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserInvitation");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.Chat", b =>
                {
                    b.HasOne("YallaGameAPISecure.Models.User", "Receiver")
                        .WithMany("ChatReceiver")
                        .HasForeignKey("ReceiverId")
                        .HasConstraintName("FK_Chat_User1");

                    b.HasOne("YallaGameAPISecure.Models.User", "Sender")
                        .WithMany("ChatSender")
                        .HasForeignKey("SenderId")
                        .HasConstraintName("FK_Chat_User");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.GameByUser", b =>
                {
                    b.HasOne("YallaGameAPISecure.Models.Game", "Game")
                        .WithMany("GameByUser")
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK_GameByUser_Game");

                    b.HasOne("YallaGameAPISecure.Models.User", "User")
                        .WithMany("GameByUser")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_GameByUser_User");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.GameInPlace", b =>
                {
                    b.HasOne("YallaGameAPISecure.Models.Game", "Game")
                        .WithMany("GameInPlace")
                        .HasForeignKey("GameId")
                        .HasConstraintName("FK_GameInPlace_Game");

                    b.HasOne("YallaGameAPISecure.Models.Place", "Place")
                        .WithMany("GameInPlace")
                        .HasForeignKey("PlaceId")
                        .HasConstraintName("FK_GameInPlace_Place");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.GroupChat", b =>
                {
                    b.HasOne("YallaGameAPISecure.Models.User", "Sender")
                        .WithMany("GroupChat")
                        .HasForeignKey("SenderId")
                        .HasConstraintName("FK_Group_Chat_User");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.ImageOfPlace", b =>
                {
                    b.HasOne("YallaGameAPISecure.Models.Place", "Place")
                        .WithMany("ImageOfPlace")
                        .HasForeignKey("PlaceId")
                        .HasConstraintName("FK_ImageOfPlace_Place");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.Invitation", b =>
                {
                    b.HasOne("YallaGameAPISecure.Models.User", "Sender")
                        .WithMany("Invitation")
                        .HasForeignKey("SenderId")
                        .HasConstraintName("FK_Invitation_User");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.OnlineUsers", b =>
                {
                    b.HasOne("YallaGameAPISecure.Models.User", "User")
                        .WithMany("OnlineUsers")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Online_Users_User");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.ReviewPlace", b =>
                {
                    b.HasOne("YallaGameAPISecure.Models.Place", "Place")
                        .WithMany("ReviewPlace")
                        .HasForeignKey("PlaceId")
                        .HasConstraintName("FK_Review_place_Place");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.ReviewUser", b =>
                {
                    b.HasOne("YallaGameAPISecure.Models.User", "Reviewer")
                        .WithMany("ReviewUserReviewer")
                        .HasForeignKey("ReviewerId")
                        .HasConstraintName("FK_Review_User_User1");

                    b.HasOne("YallaGameAPISecure.Models.User", "User")
                        .WithMany("ReviewUserUser")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_Review_User_User");
                });

            modelBuilder.Entity("YallaGameAPISecure.Models.UserInvitation", b =>
                {
                    b.HasOne("YallaGameAPISecure.Models.Invitation", "Invitation")
                        .WithMany("UserInvitation")
                        .HasForeignKey("InvitationId")
                        .HasConstraintName("FK_UserInvitation_Invitation");

                    b.HasOne("YallaGameAPISecure.Models.User", "User")
                        .WithMany("UserInvitation")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK_UserInvitation_User");
                });
#pragma warning restore 612, 618
        }
    }
}
