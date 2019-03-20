using System.Collections.Generic;
using Model.Models;

namespace Data.Repositories
{
    public interface IFilmRepository
    {
        void Add(Film newFilm);
        List<Film> GetAllFilms();
        Film GetOneFilm(int id);
        void Remove(Film film);
    }
}