using Model.Models;
using System.Collections.Generic;

namespace Service
{
    public interface IFilmService
    {
        List<Genre> GetAllGenres();
        void Complete();
        void AddNewFilm(Film film);
        List<Film> GetAllFilms();
        List<Film> GetFilmsByQuery(List<Film> films, string query);
        Film GetFilmById(int id);
    }
}