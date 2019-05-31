using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YallaGameAPISecure.Models.Repositories
{
    public class PlaceRepository : IModelRepositery<Place>
    {
        private readonly yallagameContext context;

        public PlaceRepository(yallagameContext context)
        {
            this.context = context;
        }
        public void Delete(int PlaceId)
        {
            Place place = context.Place.Find(PlaceId);
            context.Place.Remove(place);
        }

        public List<Place> getAll()
        {
            return context.Place.ToList();
        }

        public Place getById(int PlaceId)
        {
            return context.Place/*.Include(m=>m.Packages)*/.FirstOrDefault(t => t.PlaceId == PlaceId);
        }

        public void Insert(Place place)
        {
            context.Place.Add(place);
        }

        public bool ItemExists(int PlaceId)
        {
            return context.Place.Count(e => e.PlaceId == PlaceId) > 0;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Place item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
