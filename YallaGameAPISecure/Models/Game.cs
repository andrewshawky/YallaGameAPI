using System;
using System.Collections.Generic;

namespace YallaGameAPISecure.Models
{
    public partial class Game
    {
        public Game()
        {
            GameByUser = new HashSet<GameByUser>();
            GameInPlace = new HashSet<GameInPlace>();
        }

        public int GameId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public bool? Multi { get; set; }

        public ICollection<GameByUser> GameByUser { get; set; }
        public ICollection<GameInPlace> GameInPlace { get; set; }
    }
}
