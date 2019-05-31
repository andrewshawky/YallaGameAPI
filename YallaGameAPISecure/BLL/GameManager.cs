using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.Repository;

namespace YallaGameAPISecure.BLL
{
    public class GameManager : ModelRepository2<Game, yallagameContext>
    {
        //here any logic you want to add or overide it 
        public GameManager(yallagameContext context) : base(context)
        {

        }
    }
    
}
