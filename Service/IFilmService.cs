using Model.Models;
using Service.Dtos;
using System.Collections.Generic;
using Service.Helpers;

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
        FilmListServiceDto GetFilms(FilmListServiceDto filmListParametersDto);
        List<GenreServiceDto> GetAllAndSelectedGenres(ICollection<GenreServiceDto> currentFilmGenres);
        List<Genre> GetSelectedGenres(IEnumerable<GenreServiceDto> filmDtoGenres);
        void UpdateFilm(Film filmUpdate);
    }
}