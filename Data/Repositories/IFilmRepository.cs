using Data.Infrastructure;
using Model.Models;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IFilmRepository : IRepository<Film>
    {
        new Film GetById(int id);
        List<Film> GetFilmsWithPagination(int pageSize, int pageNumber);
        int GetAllFilmCount();
    }
}