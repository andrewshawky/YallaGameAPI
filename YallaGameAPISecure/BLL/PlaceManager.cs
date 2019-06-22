using Microsoft.EntityFrameworkCore;
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
        DbContext context;
        //here any logic you want to add or overide it 
        public PlaceManager(yallagameContext context) : base(context)
        {
            this.context = context;
        }

        public PlaceexDto getPlaceDtoId(int id)
        {

            Place pl = getById(id);
            PlaceexDto x =new PlaceexDto() ;
            x.PlaceId = pl.PlaceId;
            x.Name = pl.Name;
            x.Rate = pl.Rate;
            x.OpenHour = pl.OpenHour;
            x.CloseHour = pl.CloseHour;
            x.Image = pl.Image;
            x.Phone = pl.Phone;
            x.City = pl.City;
            x.Country = pl.Country;
            x.Description = pl.Description;
            x.Latitude = pl.Latitude;
            x.Longitude = pl.Longitude;
            x.Days = pl.Days;
            x.Email = pl.Email;
            return x ;
        }


        public List<Place> GetByCity(int id)
        {

           // yallagameContext context = new yallagameContext();

            string currentCity = context.Set<User>().FirstOrDefault(u => u.UserId == id).CurrentCity;
            List<Place> places = context.Set<Place>().Where(p => p.City == currentCity).ToList();
            //List<Place> places = getAll().Where(i => i.City == city).ToList();

            return places;
        }

    }
}
