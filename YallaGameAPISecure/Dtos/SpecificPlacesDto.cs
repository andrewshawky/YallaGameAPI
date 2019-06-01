using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;

namespace YallaGameAPISecure.Dtos
{
    public class SpecificPlacesDto
    {
        public string City { get; set; }
        public List<Place> places { get; set; }
    }
}
