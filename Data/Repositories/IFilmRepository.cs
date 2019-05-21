using Data.Infrastructure;
using Model.Models;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IFilmRepository : IRepository<Film>
    {
        new List<Film> GetAll();
        new Film GetById(int id);
        //List<Film> GetFilmsWithPagination(FilmListParameters filmListParameters);
        List<Film> GetFilmsWithPagination(int pageSize, int pageNumber);
        List<Film> GetFilmsBySearchQuery(int pageSize, int pageNumber, string querySearch);
        int GetAllFilmCount();
    }
}