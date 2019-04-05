using System.Collections.Generic;

namespace Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        // Marks an entity as new
        void Add(T entity);
        // Marks an entity to be removed
        void Delete(T entity);
        // Get an entity by int id
        T GetById(int id);
        // Gets all entities of type T
        List<T> GetAll();
    }
}
