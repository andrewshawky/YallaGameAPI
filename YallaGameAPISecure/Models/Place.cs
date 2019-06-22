using System;
using System.Collections.Generic;

namespace YallaGameAPISecure.Models
{
    public partial class Place
    {
        public Place()
        {
            GameInPlace = new HashSet<GameInPlace>();
            ImageOfPlace = new HashSet<ImageOfPlace>();
            ReviewPlace = new HashSet<ReviewPlace>();
        }

        public int PlaceId { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public byte[] PasswordSalt { get; set; }
        public byte[] PasswordHash { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Rate { get; set; }
        public string Image { get; set; }
        public string Days { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Description { get; set; }



        public string OpenHour { get; set; }
        public string CloseHour { get; set; }
        public int? EmailKey { get; set; }

        public ICollection<GameInPlace> GameInPlace { get; set; }
        public ICollection<ImageOfPlace> ImageOfPlace { get; set; }
        public ICollection<ReviewPlace> ReviewPlace { get; set; }
    }
}
