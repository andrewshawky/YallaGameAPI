using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.Repository;

namespace YallaGameAPISecure.BLL
{
    public class PlaceManager : ModelRepository2<Place, yallagameContext>
    {
        //here any logic you want to add or overide it 
        public PlaceManager(yallagameContext context) : base(context)
        {

        }

        
    }
}
