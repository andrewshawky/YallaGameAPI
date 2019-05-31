using System;
using System.Collections.Generic;

namespace YallaGameAPISecure.Models
{
    public partial class Invitation
    {
        public Invitation()
        {
            UserInvitation = new HashSet<UserInvitation>();
        }

        public int InvitationId { get; set; }
        public int SenderId { get; set; }

        public User Sender { get; set; }
        public ICollection<UserInvitation> UserInvitation { get; set; }
    }
}
