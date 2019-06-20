using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YallaGameAPISecure.Repository
{
    public interface IModelRepository2<T>
    {
        IQueryable<T> getAll();
        IEnumerable<T> getAllBind();


        T getById(params object[] id);
        T Insert(T item);
        bool Update(T item);
        bool Delete(T item);

    }
}
