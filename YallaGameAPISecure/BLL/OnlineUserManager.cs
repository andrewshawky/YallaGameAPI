using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.Repository;

namespace YallaGameAPISecure.BLL
{
    public class OnlineUserManager : ModelRepository2<OnlineUsers, yallagameContext>
    {
        DbContext db;
        //here any logic you want to add or overide it 
        public OnlineUserManager(yallagameContext context) : base(context)
        {
            db = context;
        }

        //public List<User> getAllOnlineUsers(int id)
        //{
        //    //db.Set<User>().Find(id);
        //    List<User> users = getAll().Where(i => i.UserId == id).Select(i=>i.User).ToList();
        //    return users;
        //}
    }
    
}
