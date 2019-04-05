using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly IDbSet<T> _dbSet;

        protected RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual T GetById(int id)
        {
            return _dbSet.Find(id);
        }

        public virtual List<T> GetAll()
        {
            return _dbSet.ToList();
        }
        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
