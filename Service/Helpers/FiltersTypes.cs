using Model.Models;
using Service.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Helpers
{
    public class FiltersTypes : IFiltersTypes
    {
        public List<Film> FilterByQuery(string query, List<Film> films, List<Film> result)
        {
            foreach (var film in films)
                if (string.Equals(film.Title, query, StringComparison.CurrentCultureIgnoreCase) && !result.Contains(film))
                    result.Add(film);
            return result;
        }

        public List<Film> FilterByGenre(List<GenreServiceDto> genres, List<Film> films, List<Film> result)
        {
            foreach (var film in films)
                foreach (var genre in genres)
                    if (!result.Contains(film) && film.Genres.Any(g => g.Id == genre.Id))
                        result.Add(film);

            return result;
        }

        public List<Film> FilterByCountry(List<CountryServiceDto> countries, List<Film> films, List<Film> result)
        {
            foreach (var film in films)
                foreach (var country in countries)
                    if (!result.Contains(film) && film.Countries.Any(c => c.Id == country.Id))
                        result.Add(film);

            return result;
        }
    }
}
