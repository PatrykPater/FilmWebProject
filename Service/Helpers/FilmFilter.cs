using Model.Models;
using Service.Dtos;
using System.Collections.Generic;

namespace Service.Helpers
{
    public class FilmFilter : IFilmFilter
    {
        private readonly FiltersTypes _filtersTypes;

        public FilmFilter(FiltersTypes filtersTypes)
        {
            _filtersTypes = filtersTypes;
        }

        public List<Film> Filter(List<Film> films, FilmListParametersServiceDto parameters)
        {
            var result = new List<Film>();

            //We can add more filters in the future
            _filtersTypes.FilterByQuery(parameters.QuerySearch, films, result);
            _filtersTypes.FilterByGenre(parameters.Genres, films, result);
            _filtersTypes.FilterByCountry(parameters.Countries, films, result);

            return result;
        }
    }
}
