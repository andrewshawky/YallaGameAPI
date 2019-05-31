using System;
using System.Collections.Generic;

namespace YallaGameAPISecure.Models
{
    public partial class GameInPlace
    {
        public int GameId { get; set; }
        public int PlaceId { get; set; }
        public string Rate { get; set; }

        public Game Game { get; set; }
        public Place Place { get; set; }
    }
}
