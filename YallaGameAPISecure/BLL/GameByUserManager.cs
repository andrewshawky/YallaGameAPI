using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.Repository;

namespace YallaGameAPISecure.BLL
{
    public class GameByUserManager : ModelRepository2<GameByUser, yallagameContext>
    {
        //here any logic you want to add or overide it 
        public GameByUserManager(yallagameContext context) : base(context)
        {

        }

        public GameByUser findbytwoid(int gameid, int userid)
        {
            GameByUser GameByUser = getAll().FirstOrDefault(i => i.GameId == gameid && i.UserId == userid);
            return GameByUser;
        }
    }
}