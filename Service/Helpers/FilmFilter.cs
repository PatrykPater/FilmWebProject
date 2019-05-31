using Model.Models;
using Service.Dtos;
using System.Collections.Generic;

namespace Service.Helpers
{
    public class FilmFilter : IFilmFilter
    {
        private readonly IFiltersTypes _filtersTypes;

        public FilmFilter(IFiltersTypes filtersTypes, IPagination pagination)
        {
            _filtersTypes = filtersTypes;
        }

        /// <summary>
        /// filters the list of films based on the provided parameters using custom filters
        /// </summary>
        /// <param name="films"></param>
        /// <param name="parameters">contains parameters required for filtering</param>
        /// <returns></returns>
        public FilmListServiceDto Filter(List<Film> films, FilmListServiceDto parameters)
        {
            var result = new List<Film>();

            _filtersTypes.FilterByQuery(parameters.QuerySearch, films, result);
            _filtersTypes.FilterByGenre(parameters.Genres, films, result);
            _filtersTypes.FilterByCountry(parameters.Countries, films, result);

            parameters.Films = result;

            return parameters;
        }
    }
}
