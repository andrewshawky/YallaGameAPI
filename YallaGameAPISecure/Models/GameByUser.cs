using System;
using System.Collections.Generic;

namespace YallaGameAPISecure.Models
{
    public partial class GameByUser
    {
        public int GameId { get; set; }
        public int UserId { get; set; }
        public int? Score { get; set; }
        public string Allgames { get; set; }

        public Game Game { get; set; }
        public User User { get; set; }
    }
}
