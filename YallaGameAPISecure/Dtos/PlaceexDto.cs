using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YallaGameAPISecure.Dtos
{
    public class PlaceexDto
    {
        public int PlaceId { get; set; }
        public string Name { get; set; }
        public string OpenHour { get; set; }
        public string CloseHour { get; set; }
        public string Rate { get; set; }
        public string Image { get; set; }
        public string Phone { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Description { get; set; }
        public string Days { get; set; }
        public string Email { get; set; }


    }
}
