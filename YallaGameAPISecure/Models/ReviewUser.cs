using System;
using System.Collections.Generic;

namespace YallaGameAPISecure.Models
{
    public partial class ReviewUser
    {
        public int ReviewId { get; set; }
        public int? UserId { get; set; }
        public int? ReviewerId { get; set; }
        public string Content { get; set; }

        public User Reviewer { get; set; }
        public User User { get; set; }
    }
}
