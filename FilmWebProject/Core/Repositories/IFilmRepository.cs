using System.Collections.Generic;
using FilmWebProject.Core.Models;

namespace FilmWebProject.Core.Repositories
{
    public interface IFilmRepository
    {
        List<Film> GetAllFilms();
        Film GetOneFilm(int id);
        void Add(Film newFilm);
        void Remove(Film film);
    }
}