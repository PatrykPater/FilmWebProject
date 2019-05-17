﻿using Data.Helpers;
using Model.Models;
using System.Collections.Generic;

namespace Service
{
    public interface IFilmService
    {
        List<Genre> GetAllGenres();
        void Complete();
        void AddNewFilm(Film film);
        List<Film> GetFilmsBySearchQuery(FilmListParameters filmListParameters);
        Film GetFilmById(int id);
        void RemoveFilm(Film film);
        ApplicationUser GetUserById(string id);
        void AddNewRating(Film film, ApplicationUser user, int value);
        Rating GetUserRating(int filmId, string userId);
        List<Film> GetFilmsWithPagination(FilmListParameters filmListParameters);
        int GetAllFilmCount();
        List<Film> FilterFilms(List<string> genre, List<string> countries, List<Film> films);
    }
}