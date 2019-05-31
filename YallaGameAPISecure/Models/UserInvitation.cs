using System;
using System.Collections.Generic;

namespace YallaGameAPISecure.Models
{
    public partial class UserInvitation
    {
        public int InvitationId { get; set; }
        public int UserId { get; set; }
        public bool? Accept { get; set; }

        public Invitation Invitation { get; set; }
        public User User { get; set; }
    }
}
