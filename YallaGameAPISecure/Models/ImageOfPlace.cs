using System;
using System.Collections.Generic;

namespace YallaGameAPISecure.Models
{
    public partial class ImageOfPlace
    {
        public int PlaceId { get; set; }
        public int ImageOfPlaceId { get; set; }
        public string Name { get; set; }

        public Place Place { get; set; }
    }
}
