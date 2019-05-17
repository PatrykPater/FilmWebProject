using Data.Helpers;
using Data.Infrastructure;
using Model.Models;
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

        public List<Film> GetAllFilms()
        {
            return _unitOfWork.Films.GetAll();
        }

        public List<Film> GetFilmsBySearchQuery(FilmListParameters filmListParameters)
        {
            return _unitOfWork.Films.GetFilmsBySearchQuery(filmListParameters);
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
            return _unitOfWork.Films.GetFilmsWithPagination(filmListParameters);
        }

        public int GetAllFilmCount()
        {
            return _unitOfWork.Films.GetAllFilmCount();
        }

        public List<Film> FilterFilms(List<string> genre, List<string> countries, List<Film> films)
        {
            throw new System.NotImplementedException();
        }
    }
}
