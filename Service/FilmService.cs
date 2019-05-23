using Data.Infrastructure;
using Model.Models;
using Service.Dtos;
using System.Collections.Generic;
using System.Linq;

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

        public List<Film> GetFilmsBySearchQuery(FilmListParametersDto filmListParameters)
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

        public List<Film> GetFilmsWithPagination(FilmListParametersDto filmListParameters)
        {
            var pageSize = filmListParameters.PageSize;
            var pageNumber = filmListParameters.PageNumber - 1;

            return _unitOfWork.Films.GetFilmsWithPagination(pageSize, pageNumber);
        }

        public int GetAllFilmCount()
        {
            return _unitOfWork.Films.GetAllFilmCount();
        }

        public List<Film> Filter(FilmListParametersDto filmListParametersDto)
        {         
            var result = new List<Film>();
            var genresFromDb = new List<Genre>();
            var countriesFromDb = new List<Country>();

            if (!filmListParametersDto.Genres.Any() && !filmListParametersDto.Countries.Any() && string.IsNullOrWhiteSpace(filmListParametersDto.QuerySearch))
            {
                return _unitOfWork.Films.GetFilmsWithPagination(filmListParametersDto.PageSize,
                    filmListParametersDto.PageNumber);
            }

            var filmsFromDb = _unitOfWork.Films.GetAll();

            foreach (var genre in filmListParametersDto.Genres)
            {
                genresFromDb.Add(_unitOfWork.Genres.Get(g => g.Name == genre));
            }

            foreach (var country in filmListParametersDto.Countries)
            {
                countriesFromDb.Add(_unitOfWork.Countries.Get(g => g.Name == country));
            }

            foreach (var film in filmsFromDb)
            {
                if (!string.IsNullOrWhiteSpace(filmListParametersDto.QuerySearch))
                {
                    if (film.Title.ToLower() == filmListParametersDto.QuerySearch.ToLower())
                    {
                        result.Add(film);
                    }
                }

                foreach (var genre in genresFromDb)
                {
                    if (film.Genres.Contains(genre))
                    {
                        result.Add(film);
                    }
                }

                foreach (var country in countriesFromDb)
                {
                    if (film.Countries.Contains(country))
                    {
                        result.Add(film);
                    }
                }
            }

            return result;
        }
    }
}
