using Data.Infrastructure;
using Model.Models;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface INewsRepository : IRepository<News>
    {
        new List<News> GetAll();
    }
}