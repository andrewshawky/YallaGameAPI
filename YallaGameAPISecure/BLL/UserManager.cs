using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using YallaGameAPISecure.Models;
using YallaGameAPISecure.Repository;

namespace YallaGameAPISecure.BLL
{
    public class UserManager : ModelRepository2<User, yallagameContext>
    {
        //here any logic you want to add or overide it 
        public UserManager(yallagameContext context) : base(context)
        {
           
        }
        public List<User> GetByCity(string city)
        {
            List<User> users = getAll().Where(i => i.CurrentCity == city).ToList();

            return users;
        }

        public bool UpdateCity(int id,string city)
        {

           User user = getAll().Where(i => i.UserId == id).FirstOrDefault();
            user.CurrentCity = city;
            return Update(user);

            
        }



        public List<User> getAllOnlineUsers(int id)
        {
            List<User> users = getAll().Where(i=>i.Online==true&&i.UserId!=id).ToList();
            
            return users;
        }



    }
}
