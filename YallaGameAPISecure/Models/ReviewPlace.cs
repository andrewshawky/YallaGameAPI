using System;
using System.Collections.Generic;

namespace YallaGameAPISecure.Models
{
    public partial class ReviewPlace
    {
        public int? PlaceId { get; set; }
        public int? UserId { get; set; }
        public int ReviewId { get; set; }
        public string Content { get; set; }

        public Place Place { get; set; }
    }
}
