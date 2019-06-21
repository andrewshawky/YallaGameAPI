using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YallaGameAPISecure.Dtos
{
    public class GameDtos
    {
        public int GameId { get; set; }
        public string Name { get; set; }
        public string Describtion { get; set; }
        public string Image { get; set; }
        public bool? Multi { get; set; }
    }
}
