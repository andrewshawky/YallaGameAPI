using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YallaGameAPISecure.Models
{
    public partial class User
    {
        public User()
        {
            ChatReceiver = new HashSet<Chat>();
            ChatSender = new HashSet<Chat>();
            GameByUser = new HashSet<GameByUser>();
            GroupChat = new HashSet<GroupChat>();
            Invitation = new HashSet<Invitation>();
            OnlineUsers = new HashSet<OnlineUsers>();
            ReviewUserReviewer = new HashSet<ReviewUser>();
            ReviewUserUser = new HashSet<ReviewUser>();
            UserInvitation = new HashSet<UserInvitation>();
        }
        
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string EmailKey { get; set; }
        public bool? Online { get; set; }

        public ICollection<Chat> ChatReceiver { get; set; }
        public ICollection<Chat> ChatSender { get; set; }
        public ICollection<GameByUser> GameByUser { get; set; }
        public ICollection<GroupChat> GroupChat { get; set; }
        public ICollection<Invitation> Invitation { get; set; }
        public ICollection<OnlineUsers> OnlineUsers { get; set; }
        public ICollection<ReviewUser> ReviewUserReviewer { get; set; }
        public ICollection<ReviewUser> ReviewUserUser { get; set; }
        public ICollection<UserInvitation> UserInvitation { get; set; }
    }
}
