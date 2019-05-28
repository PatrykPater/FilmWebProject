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

        //We can easily add more filters in the future

        /// <summary>
        /// filters the list of films based on the provided parameters using custom filters
        /// </summary>
        /// <param name="films"></param>
        /// <param name="parameters">contains parameters required for filtering</param>
        /// <returns></returns>
        public List<Film> Filter(List<Film> films, FilmListParametersServiceDto parameters)
        {
            var result = new List<Film>();

            _filtersTypes.FilterByQuery(parameters.QuerySearch, films, result);
            _filtersTypes.FilterByGenre(parameters.Genres, films, result);
            _filtersTypes.FilterByCountry(parameters.Countries, films, result);

            return result;
        }
    }
}
