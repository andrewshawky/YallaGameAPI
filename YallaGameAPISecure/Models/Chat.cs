using System;
using System.Collections.Generic;

namespace YallaGameAPISecure.Models
{
    public partial class Chat
    {
       
        public int ChatId { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public DateTime? Date { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; } = false;


        public User Receiver { get; set; }
        public User Sender { get; set; }
    }
}
