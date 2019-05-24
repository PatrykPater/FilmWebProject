using Model.Models;
using Service.Dtos;
using System.Collections.Generic;

namespace Service
{
    public interface IFilmService
    {
        List<Genre> GetAllGenres();
        void Complete();
        void AddNewFilm(Film film);
        Film GetFilmById(int id);
        void RemoveFilm(Film film);
        ApplicationUser GetUserById(string id);
        void AddNewRating(Film film, ApplicationUser user, int value);
        Rating GetUserRating(int filmId, string userId);
        List<Film> GetFilms(FilmListParametersDto filmListParametersDto);
        int GetMaxPageNumber(int pageSize);
        List<GenreDto> GetAllAndSelectedGenres(ICollection<Genre> currentFilmGenres, List<GenreDto> genresDto);
        List<Genre> GetSelectedGenres(IEnumerable<GenreDto> filmDtoGenres);
    }
}