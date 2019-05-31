using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.Repository;

namespace YallaGameAPISecure.BLL
{
    public class OnlineUserManager : ModelRepository2<OnlineUsers, yallagameContext>
    {
        //here any logic you want to add or overide it 
        public OnlineUserManager(yallagameContext context) : base(context)
        {

        }
    }
    
}
