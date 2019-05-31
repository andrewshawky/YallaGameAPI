using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.Repository;

namespace YallaGameAPISecure.BLL
{
    public class UserInvitationManager : ModelRepository2<UserInvitation, yallagameContext>
    {
        //here any logic you want to add or overide it 
        public UserInvitationManager(yallagameContext context) : base(context)
        {

        }

        public UserInvitation findbytwoid(int invitationid, int userid)
        {
            UserInvitation UserInvitation = getAll().FirstOrDefault(i => i.InvitationId == invitationid && i.UserId == userid);
            return UserInvitation;
        }
    }
   
}
