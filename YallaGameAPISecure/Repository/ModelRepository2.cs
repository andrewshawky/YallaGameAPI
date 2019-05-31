using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace YallaGameAPISecure.Repository
{
    public class ModelRepository2<T, TContext> : IModelRepository2<T>
        where T : class
        where TContext : DbContext, new()
    {
        private TContext context;
        private DbSet<T> set;
        public ModelRepository2(TContext context)
        {
            this.context = context;
            set = context.Set<T>();
        }


        public bool Delete(T item)
        {
            set.Remove(item);
            return context.SaveChanges() > 0 ? true : false;
        }

        public IQueryable<T> getAll()
        {
            return set;
        }

        public IEnumerable<T> getAllBind()
        {
            return set.ToList();
        }

        public T getById(params object[] id)
        {
            return set.Find(id);
        }

        public T Insert(T item)
        {
            set.Add(item);
            return context.SaveChanges() > 0 ? item : null;
        }


        public bool Update(T item)
        {
            context.Entry(item).State = EntityState.Modified;
            return context.SaveChanges() > 0 ? true : false;

        }
    }
}
