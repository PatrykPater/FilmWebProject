using Data.Helpers;
using Data.Infrastructure;
using Model.Models;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IFilmRepository : IRepository<Film>
    {
        new List<Film> GetAll();
        new Film GetById(int id);
        List<Film> GetFilmsWithPagination(FilmListParameters filmListParameters);
        int GetAllFilmCount();
    }
}