using Model.Models;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Helpers
{
    public class FilmFilter
    {
        public List<Film> Filter(List<Film> films, FilmListParametersDto parameters)
        {
            var result = new List<Film>();
            var genres = parameters.Genres;
            var countries = parameters.Countries;
            var query = parameters.QuerySearch;

            foreach (var film in films)
            {
                if (!string.IsNullOrWhiteSpace(query))
                    FilterByQuery(query, film, result);

                FilterByGenre(genres, film, result);
                FilterByCountry(countries, film, result);
            }

            return result;
        }

        public void FilterByQuery(string query, Film film, List<Film> result)
        {
            if (string.Equals(film.Title, query, StringComparison.CurrentCultureIgnoreCase))
                result.Add(film);
        }

        public void FilterByGenre(List<Genre> genres, Film film, List<Film> result)
        {
            foreach (var genre in genres)
                if (film.Genres.Any(g => g.Name == genre.Name))
                    result.Add(film);
        }

        public void FilterByCountry(List<Country> countries, Film film, List<Film> result)
        {
            foreach (var country in countries)
                if (film.Countries.Any(g => g.Name == country.Name))
                    result.Add(film);
        }
    }
}
