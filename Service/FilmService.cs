using Data.Infrastructure;
using Model.Models;
using Service.Dtos;
using System.Collections.Generic;

namespace Service
{
    public class FilmService : ServiceBase, IFilmService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FilmService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Genre> GetAllGenres()
        {
            return _unitOfWork.Genres.GetAll();
        }

        public void AddNewFilm(Film film)
        {
            _unitOfWork.Films.Add(film);
        }

        public List<Film> GetFilmsBySearchQuery(FilmListParameters filmListParameters)
        {
            var pageSize = filmListParameters.PageSize;
            var pageNumber = filmListParameters.PageNumber - 1;
            var querySearch = filmListParameters.QuerySearch;

            return _unitOfWork.Films.GetFilmsBySearchQuery(pageSize, pageNumber, querySearch);
        }

        public Film GetFilmById(int id)
        {
            return _unitOfWork.Films.GetById(id);
        }

        public void RemoveFilm(Film film)
        {
            _unitOfWork.Films.Delete(film);
        }

        public ApplicationUser GetUserById(string id)
        {
            return _unitOfWork.Users.GetUserById(id);
        }

        public void AddNewRating(Film film, ApplicationUser user, int value)
        {
            var newRating = new Rating { Film = film, User = user, Value = value };
            _unitOfWork.Ratings.Add(newRating);
        }

        public Rating GetUserRating(int filmId, string userId)
        {
            return _unitOfWork.Ratings.GetUserRating(filmId, userId);
        }

        public List<Film> GetFilmsWithPagination(FilmListParameters filmListParameters)
        {
            var pageSize = filmListParameters.PageSize;
            var pageNumber = filmListParameters.PageNumber - 1;

            return _unitOfWork.Films.GetFilmsWithPagination(pageSize, pageNumber);
        }

        public int GetAllFilmCount()
        {
            return _unitOfWork.Films.GetAllFilmCount();
        }

        public List<Film> FilterFilms(List<string> genres, List<string> countries, List<Film> films)
        {
            var filteredListOfFilms = new List<Film>();
            var genresFromDb = new List<Genre>();
            var countriesFromDb = new List<Country>();

            foreach (var genre in genres)
            {
                genresFromDb.Add(_unitOfWork.Genres.Get(g => g.Name == genre));
            }

            foreach (var country in countries)
            {
                countriesFromDb.Add(_unitOfWork.Countries.Get(g => g.Name == country));
            }

            foreach (var film in films)
            {
                foreach (var genre in genresFromDb)
                {
                    if (film.Genres.Contains(genre))
                    {
                        filteredListOfFilms.Add(film);
                    }
                }

                foreach (var country in countriesFromDb)
                {
                    if (film.Countries.Contains(country))
                    {
                        filteredListOfFilms.Add(film);
                    }
                }
            }
            return filteredListOfFilms;
        }
    }
}
