using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Delete(T entity);
        T GetById(int id);
        List<T> GetAll();
        void Delete(Expression<Func<T, bool>> where);
        IEnumerable<T> GetMany(Expression<Func<T, bool>> where);
        T Get(Expression<Func<T, bool>> where);
    }
}
