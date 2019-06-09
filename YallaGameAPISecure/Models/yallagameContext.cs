using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace YallaGameAPISecure.Models
{
    public partial class yallagameContext : DbContext
    {
        public yallagameContext()
        {
        }

        public yallagameContext(DbContextOptions<yallagameContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Chat> Chat { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GameByUser> GameByUser { get; set; }
        public virtual DbSet<GameInPlace> GameInPlace { get; set; }
        public virtual DbSet<GroupChat> GroupChat { get; set; }
        public virtual DbSet<ImageOfPlace> ImageOfPlace { get; set; }
        public virtual DbSet<Invitation> Invitation { get; set; }
        public virtual DbSet<OnlineUsers> OnlineUsers { get; set; }
        public virtual DbSet<Place> Place { get; set; }
        public virtual DbSet<ReviewPlace> ReviewPlace { get; set; }
        public virtual DbSet<ReviewUser> ReviewUser { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserInvitation> UserInvitation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=latestYallaGameFromScratch;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Chat>(entity =>
            {
                entity.Property(e => e.ChatId)
                    .HasColumnName("Chat_Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date).HasColumnType("date");
                entity.Property(e => e.IsDeleted);
                entity.Property(e => e.Description)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ReceiverId).HasColumnName("Receiver_Id");

                entity.Property(e => e.SenderId).HasColumnName("Sender_Id");

                entity.HasOne(d => d.Receiver)
                    .WithMany(p => p.ChatReceiver)
                    .HasForeignKey(d => d.ReceiverId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chat_User1");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.ChatSender)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Chat_User");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.GameId)
                    .HasColumnName("Game_Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GameByUser>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.UserId });

                entity.Property(e => e.GameId).HasColumnName("Game_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.Property(e => e.Allgames)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameByUser)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameByUser_Game");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.GameByUser)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameByUser_User");
            });

            modelBuilder.Entity<GameInPlace>(entity =>
            {
                entity.HasKey(e => new { e.GameId, e.PlaceId });

                entity.Property(e => e.GameId).HasColumnName("Game_Id");

                entity.Property(e => e.PlaceId).HasColumnName("Place_Id");

                entity.Property(e => e.Rate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.GameInPlace)
                    .HasForeignKey(d => d.GameId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameInPlace_Game");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.GameInPlace)
                    .HasForeignKey(d => d.PlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_GameInPlace_Place");
            });

            modelBuilder.Entity<GroupChat>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.ToTable("Group_Chat");

                entity.Property(e => e.GroupId)
                    .HasColumnName("Group_Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.SenderId).HasColumnName("Sender_Id");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.GroupChat)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Group_Chat_User");
            });

            modelBuilder.Entity<ImageOfPlace>(entity =>
            {
                entity.HasKey(e => new { e.PlaceId, e.ImageOfPlaceId });

                entity.Property(e => e.PlaceId).HasColumnName("Place_Id");

                entity.Property(e => e.ImageOfPlaceId).HasColumnName("ImageOfPlace_Id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.ImageOfPlace)
                    .HasForeignKey(d => d.PlaceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ImageOfPlace_Place");
            });

            modelBuilder.Entity<Invitation>(entity =>
            {
                entity.Property(e => e.InvitationId)
                    .HasColumnName("Invitation_Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.SenderId).HasColumnName("Sender_Id");

                entity.HasOne(d => d.Sender)
                    .WithMany(p => p.Invitation)
                    .HasForeignKey(d => d.SenderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invitation_User");
            });

            modelBuilder.Entity<OnlineUsers>(entity =>
            {
                entity.HasKey(e => e.OnlineId);

                entity.ToTable("Online_Users");

                entity.Property(e => e.OnlineId)
                    .HasColumnName("Online_Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Lang)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Lat)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.OnlineUsers)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Online_Users_User");
            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.Property(e => e.PlaceId)
                    .HasColumnName("Place_Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CloseHour)
                    .HasMaxLength(100)
                    .IsUnicode(false);

               

                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Days)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude);
                entity.Property(e => e.Longitude);



                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OpenHour)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash);

                entity.Property(e => e.PasswordSalt);
                  

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Rate)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ReviewPlace>(entity =>
            {
                entity.HasKey(e => e.ReviewId);

                entity.ToTable("Review_place");

                entity.Property(e => e.ReviewId).HasColumnName("Review_Id");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PlaceId).HasColumnName("Place_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.ReviewPlace)
                    .HasForeignKey(d => d.PlaceId)
                    .HasConstraintName("FK_Review_place_Place");
            });

            modelBuilder.Entity<ReviewUser>(entity =>
            {
                entity.HasKey(e => e.ReviewId);

                entity.ToTable("Review_User");

                entity.Property(e => e.ReviewId).HasColumnName("Review_Id");

                entity.Property(e => e.Content)
                    .HasColumnName("content")
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ReviewerId).HasColumnName("Reviewer_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Reviewer)
                    .WithMany(p => p.ReviewUserReviewer)
                    .HasForeignKey(d => d.ReviewerId)
                    .HasConstraintName("FK_Review_User_User1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ReviewUserUser)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Review_User_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId)
                    .HasColumnName("User_Id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.City)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CurrentCity)
                    .HasMaxLength(100)
                    .IsUnicode(false);


                entity.Property(e => e.Country)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmailKey)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordHash);


                entity.Property(e => e.PasswordSalt);
                    

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserInvitation>(entity =>
            {
                entity.HasKey(e => new { e.InvitationId, e.UserId });
              // entity.Property(p => p.UserId).(DatabaseGeneratedOption.Identity);
                entity.Property(e => e.InvitationId).HasColumnName("Invitation_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");

                entity.HasOne(d => d.Invitation)
                    .WithMany(p => p.UserInvitation)
                    .HasForeignKey(d => d.InvitationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInvitation_Invitation");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserInvitation)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserInvitation_User");
            });
        }
    }
}
