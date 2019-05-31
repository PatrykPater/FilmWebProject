using System.Collections.Generic;
using Model.Models;
using Service.Dtos;

namespace Service.Helpers
{
    public interface IFiltersTypes
    {
        List<Film> FilterByCountry(List<CountryServiceDto> countries, List<Film> films, List<Film> result);
        List<Film> FilterByGenre(List<GenreServiceDto> genres, List<Film> films, List<Film> result);
        List<Film> FilterByQuery(string query, List<Film> films, List<Film> result);
    }
}