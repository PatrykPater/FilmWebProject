using Model.Models;
using Service.Dtos;
using System;
using System.Collections.Generic;

namespace Service.Helpers
{
    public class FilmFilter
    {
        public List<Film> Filter(List<Film> films, FilmListParametersDto parameters)
        {
            var result = new List<Film>();
            var genresFromDb = new List<Genre>();
            var countriesFromDb = new List<Country>();

            var genres = _filmServiceHelper.Get();
            var countries = _filmServiceHelper.Get();

            foreach (var genre in parameters.Genres)
            {
                genresFromDb.Add(_unitOfWork.Genres.Get(g => g.Name == genre));
            }

            foreach (var genre in parameters.Genres)
            {
                genresFromDb.Add(_unitOfWork.Genres.Get(g => g.Name == genre));
            }

            foreach (var country in parameters.Countries)
            {
                countriesFromDb.Add(_unitOfWork.Countries.Get(g => g.Name == country));
            }

            foreach (var film in films)
            {
                if (!string.IsNullOrWhiteSpace(parameters.QuerySearch))
                {
                    if (string.Equals(film.Title, parameters.QuerySearch, StringComparison.CurrentCultureIgnoreCase))
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
