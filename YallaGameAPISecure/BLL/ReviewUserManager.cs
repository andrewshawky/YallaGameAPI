using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.Repository;

namespace YallaGameAPISecure.BLL
{
    public class ReviewUserManager : ModelRepository2<ReviewUser, yallagameContext>
    {
        //here any logic you want to add or overide it 
        public ReviewUserManager(yallagameContext context) : base(context)
        {

        }
    }
   
}
