using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.Repository;

namespace YallaGameAPISecure.BLL
{
    public class GameInPlaceManager : ModelRepository2<GameInPlace, yallagameContext>
    {
        //here any logic you want to add or overide it 
        public GameInPlaceManager(yallagameContext context) : base(context)
        {
           
        }
        
        public GameInPlace findbytwoid(int placeid,int gameid)
        {
            GameInPlace GameInPlace = getAll().FirstOrDefault(i => i.PlaceId == placeid && i.GameId == gameid);
            return GameInPlace;
        }
        public List<GameInPlace> findByPlaceId(int placeid)
        {
            List<GameInPlace>  GameInPlaces = getAll().Where(i => i.PlaceId == placeid).ToList();
            return GameInPlaces;
        }
    }
    
}
