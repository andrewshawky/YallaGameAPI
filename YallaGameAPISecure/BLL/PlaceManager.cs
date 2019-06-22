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


        //send id of place and return specific data of this place  
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


        //update part of place by place id 
        public bool Updatev1(Place item)
        {
            Place oldplace = context.Set<Place>().Find(item.PlaceId);
            oldplace.Name = item.Name;
            oldplace.Email = item.Email;
            oldplace.Country = item.Country;
            oldplace.City = item.City;
            oldplace.OpenHour = item.OpenHour;
            oldplace.CloseHour = item.CloseHour;
            oldplace.Phone = item.Phone;
            oldplace.Days = item.Days;
            return context.SaveChanges() > 0 ? true : false;

        }

    }
}
