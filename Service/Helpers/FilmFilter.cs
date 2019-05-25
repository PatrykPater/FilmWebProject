using Model.Models;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Helpers
{
    public class FilmFilter
    {
        public List<Film> Filter(List<Film> films, FilmListParametersServiceDto parameters)
        {
            var result = new List<Film>();
            var genres = parameters.Genres;
            var countries = parameters.Countries;
            var query = parameters.QuerySearch;

            if (!string.IsNullOrWhiteSpace(query))
                films = FilterByQuery(query, films);

            foreach (var film in films)
            {
                FilterByGenre(genres, film, result);
                FilterByCountry(countries, film, result);
            }

            return result;
        }

        public List<Film> FilterByQuery(string query, List<Film> films)
        {
            return films.Where(f => string.Equals(f.Title, query, StringComparison.CurrentCultureIgnoreCase)).ToList();
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
