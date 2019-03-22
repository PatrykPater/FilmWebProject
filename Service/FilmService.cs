using Data.Infrastructure;
using Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class FilmService : IFilmService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FilmService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Genre> GetAllGenres()
        {
            return _unitOfWork.Genres.GetAllGenres();
        }

        public void AddNewFilm(Film film)
        {
            _unitOfWork.Films.Add(film);
        }

        public void Complete()
        {
            _unitOfWork.Complete();
        }

        public List<Film> GetAllFilms()
        {
            return _unitOfWork.Films.GetAllFilms();
        }

        public List<Film> GetFilmsByQuery(List<Film> films, string query)
        {
            var lower = query.ToLower();

            films = films
               .Where(g =>
                   g.Title.ToLower().Contains(lower)).ToList();

            return films;
        }

        public Film GetFilmById(int id)
        {
            return _unitOfWork.Films.GetOneFilm(id);
        }

        public void RemoveFilm(Film film)
        {
            _unitOfWork.Films.Remove(film);
        }

        public ApplicationUser GetUserById(string id)
        {
            return _unitOfWork.Users.GetUserById(id);
        }

        public void AddNewRating(Film film, ApplicationUser user, int value)
        {
            var newRating = new Rating { Film = film, User = user, Value = value };
            _unitOfWork.Ratings.AddNewRating(newRating);
        }

        public Rating GetUserRating(int filmId, string userId)
        {
            return _unitOfWork.Ratings.GetUserRating(filmId, userId);
        }
    }
}
