using System;
using System.Collections.Generic;

namespace YallaGameAPISecure.Models
{
    public partial class GroupChat
    {
        public int GroupId { get; set; }
        public int SenderId { get; set; }
        public string Description { get; set; }
        public DateTime? Date { get; set; }

        public User Sender { get; set; }
    }
}
