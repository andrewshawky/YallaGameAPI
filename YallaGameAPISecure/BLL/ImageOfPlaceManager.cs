using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.Repository;

namespace YallaGameAPISecure.BLL
{
    public class ImageOfPlaceManager : ModelRepository2<ImageOfPlace, yallagameContext>
    {
        //here any logic you want to add or overide it 
        public ImageOfPlaceManager(yallagameContext context) : base(context)
        {

        }

        public ImageOfPlace findbytwoid(int imageofplaceid, int placeid)
        {
            ImageOfPlace ImageOfPlace = getAll().FirstOrDefault(i => i.ImageOfPlaceId == imageofplaceid && i.PlaceId == placeid);
            return ImageOfPlace;
        }
    }
}
