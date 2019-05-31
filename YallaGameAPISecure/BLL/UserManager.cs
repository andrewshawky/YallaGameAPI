using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.Repository;

namespace YallaGameAPISecure.BLL
{
    public class UserManager : ModelRepository2<User, yallagameContext>
    {
        //here any logic you want to add or overide it 
        public UserManager(yallagameContext context) : base(context)
        {
           
        }
    }
}
