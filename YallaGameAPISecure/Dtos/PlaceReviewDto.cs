using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YallaGameAPISecure.Dtos
{
    public class PlaceReviewDto
    {
        public int? PlaceId { get; set; }
        public int? UserId { get; set; }
        public string Content { get; set; }
        public int Rate { get; set; }
        public string Image { get; set; }
        public string UserName { get; set; }
    }
}
