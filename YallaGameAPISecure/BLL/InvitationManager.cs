using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.Repository;

namespace YallaGameAPISecure.BLL
{
    public class InvitationManager : ModelRepository2<Invitation, yallagameContext>
    {
        //here any logic you want to add or overide it 
        public InvitationManager(yallagameContext context) : base(context)
        {

        }
    }
}
