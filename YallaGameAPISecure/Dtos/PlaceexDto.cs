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
    }
}
