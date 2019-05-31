using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YallaGameAPISecure.Models.Repositories
{
    public class UserRepository : IModelRepositery<User>
    {
        private readonly yallagameContext context;

        public UserRepository(yallagameContext context)
        {
            this.context = context;
        }
        public void Delete(int UserId)
        {
            User user = context.User.Find(UserId);
            context.User.Remove(user);
        }

        public List<User> getAll()
        {
            return context.User.ToList();
        }

        public User getById(int UserId)
        {
            return context.User/*.Include(m=>m.Packages)*/.FirstOrDefault(t => t.UserId == UserId);
        }

        public void Insert(User user)
        {
            context.User.Add(user);
        }

        public bool ItemExists(int UserId)
        {
            return context.User.Count(e => e.UserId == UserId) > 0;
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Update(User item)
        {
            context.Entry(item).State = EntityState.Modified;
        }
    }
}
