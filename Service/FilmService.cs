﻿using System;
using Data.Infrastructure;
using Model.Models;
using Service.Dtos;
using Service.Helpers;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class FilmService : ServiceBase, IFilmService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFilmFilter _filmFiler;
        private readonly IPagination _pagination;

        public FilmService(IUnitOfWork unitOfWork, IFilmFilter filmFiler, IPagination pagination) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _filmFiler = filmFiler;
            _pagination = pagination;
        }

        public List<Genre> GetAllGenres()
        {
            return _unitOfWork.Genres.GetAll();
        }

        public void AddNewFilm(Film film)
        {
            _unitOfWork.Films.Add(film);
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

        /// <summary>
        /// returns list of films based on provided parameters
        /// </summary>
        /// <param name="filmListParametersDto">contains parameters required to filter/sort list of films</param>
        /// <returns></returns>
        public FilmListServiceDto GetFilms(FilmListServiceDto filmListParametersDto)
        {
            var filmsFromDb = _unitOfWork.Films.GetAll();

            if (!ListOfFilterParameters.CheckParameters(filmListParametersDto))
            {
                filmListParametersDto.MaxPageNumber = GetMaxPageNumber(filmsFromDb.Count, filmListParametersDto.PageSize);
                filmListParametersDto.Films = _pagination.PerformPagination(filmsFromDb, filmListParametersDto);

                return filmListParametersDto;
            }

            var result = _filmFiler.Filter(filmsFromDb, filmListParametersDto);
            result.MaxPageNumber = GetMaxPageNumber(result.Films.Count, filmListParametersDto.PageSize);
            result.Films = _pagination.PerformPagination(result.Films, filmListParametersDto);

            return result;
        }

        public int GetMaxPageNumber(int filmCount, int pageSize)
        {
            var var1 = Convert.ToDouble(filmCount);
            var var2 = Convert.ToDouble(pageSize);

            var division = var1 / var2;

            var roundUp = Math.Ceiling(division);
            var result = Convert.ToInt32(roundUp);

            return result;
        }

        /// <summary>
        /// returns the list of all selected genres (with saved isChecked property)
        /// </summary>
        /// <param name="currentFilmGenres">selected genres</param>
        /// <returns></returns>
        public List<GenreServiceDto> GetAllAndSelectedGenres(ICollection<GenreServiceDto> currentFilmGenres)
        {
            var genresDto = _unitOfWork.Genres.GetAll()
                .Select(CreteGenreServiceDto)
                .ToList();

            foreach (var genreDto in genresDto)
                foreach (var currentFilmGenre in currentFilmGenres)
                    if (currentFilmGenre.Id == genreDto.Id)
                        genreDto.IsChecked = true;

            return genresDto;
        }

        /// <summary>
        /// returns the list of selected genres
        /// </summary>
        /// <param name="filmDtoGenres">list of genres both selected and not</param>
        /// <returns></returns>
        public List<Genre> GetSelectedGenres(IEnumerable<GenreServiceDto> filmDtoGenres)
        {
            return (from genreDto in filmDtoGenres where genreDto.IsChecked select _unitOfWork.Genres.GetById(genreDto.Id)).ToList();
        }

        public void UpdateFilm(Film filmUpdate)
        {
            _unitOfWork.Films.Update(filmUpdate);
        }

        /// <summary>
        /// maps Genre object into GenreServiceDto
        /// </summary>
        /// <param name="genre"></param>
        /// <returns></returns>
        public GenreServiceDto CreteGenreServiceDto(Genre genre)
        {
            return new GenreServiceDto()
            {
                Name = genre.Name,
                Id = genre.Id
            };
        }
    }
}
