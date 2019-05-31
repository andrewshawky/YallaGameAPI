using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.Repository;

namespace YallaGameAPISecure.BLL
{
    public class GroupChatManager : ModelRepository2<GroupChat, yallagameContext>
    {
        //here any logic you want to add or overide it 
        public GroupChatManager(yallagameContext context) : base(context)
        {

        }
    
    }
}
