using System;
using System.Collections.Generic;

namespace YallaGameAPISecure.Models
{
    public partial class OnlineUsers
    {
        public int? UserId { get; set; }
        public string Lang { get; set; }
        public string Lat { get; set; }
        public int OnlineId { get; set; }

        public User User { get; set; }
    }
}
