using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.Repository;

namespace YallaGameAPISecure.BLL
{
    public class ReviewPlaceManager : ModelRepository2<ReviewPlace, yallagameContext>
    {
        //here any logic you want to add or overide it 
        public ReviewPlaceManager(yallagameContext context) : base(context)
        {

        }
    }
    
}
