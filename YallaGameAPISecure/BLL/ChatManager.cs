using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.Repository;

namespace YallaGameAPISecure.BLL
{
    public class ChatManager : ModelRepository2<Chat, yallagameContext>
    {
        //here any logic you want to add or overide it 
        public ChatManager(yallagameContext context) : base(context)
        {

        }
    }
}
