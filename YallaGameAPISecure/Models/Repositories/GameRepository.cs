using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YallaGameAPISecure.Models.Repositories
{
    public class GameRepository: IModelRepositery<Game>  
    {
        private readonly yallagameContext context;

        public GameRepository(yallagameContext context)
        {
            this.context = context;
        }
        public void Delete(int GameId)
        {
            Game game = context.Game.Find(GameId);
            context.Game.Remove(game);
        }

        public List<Game> getAll()
        {
            return context.Game.ToList();
        }

        public Game getById(int GameId)
        {
            return context.Game/*.Include(m=>m.Packages)*/.FirstOrDefault(t => t.GameId == GameId);
        }

        public void Insert(Game game)
        {
             context.Game.Add(game);
        }

        public bool ItemExists(int GameId)
        {
            return context.Game.Count(e => e.GameId == GameId) > 0;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(Game game)
        {
            context.Entry(game).State = EntityState.Modified;
        }
    }
}
