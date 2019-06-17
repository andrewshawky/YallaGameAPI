using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Dtos;
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

        public PlaceexDto getPlaceDtoId(int id)
        {
            Place pl = getById(id);
            PlaceexDto x=new PlaceexDto() ;
            x.PlaceId = pl.PlaceId;
            x.Rate = pl.Rate;
            x.OpenHour = pl.OpenHour;
            x.CloseHour = pl.CloseHour;
            x.Image = pl.Image;
            return x ;
        }


        public List<Place> GetByCity(string city)
        {
            List<Place> places = getAll().Where(i => i.City == city).ToList();

            return places;
        }

    }
}
