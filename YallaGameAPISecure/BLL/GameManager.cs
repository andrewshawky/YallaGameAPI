using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Dtos;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.Repository;

namespace YallaGameAPISecure.BLL
{
    public class GameManager : ModelRepository2<Game, yallagameContext>
    {
        DbContext context;
        
        //here any logic you want to add or overide it 
        public GameManager(yallagameContext context) : base(context)
        {
            this.context = context;
        }


        //function take place id and return games in this place
        public List<GameDtos> GetGamesByPlaceID(int id)
        {

            // yallagameContext context = new yallagameContext();
            List<int> ids = new List<int>();
            List<GameInPlace> gamesinplace = context.Set<GameInPlace>().Where(i=>i.PlaceId==id).ToList();
            List<Game> games = new List<Game>();
            foreach (GameInPlace i in gamesinplace)
            {
                ids.Add(i.GameId); 

            }

            foreach (int i in ids)
            {
                //ids.Add(context.Set<GameInPlace>().FirstOrDefault(u => u.PlaceId == i.PlaceId).GameId);
                games.Add(context.Set<Game>().FirstOrDefault(j=>j.GameId==i));
            }
            List<GameDtos> xlist = new List<GameDtos>();
            GameDtos x;


            foreach (Game i in games)
            {
                x = new GameDtos();
                x.GameId = i.GameId;
                x.Name = i.Name;
                x.Describtion = i.Description;
                x.Multi = i.Multi;
                x.Image = i.Image;

                xlist.Add(x);
            }
            return xlist ;
        }
    }
    
}
