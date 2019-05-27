using Service.Dtos;
using System.Linq;

namespace Service.Helpers
{
    public class ListOfFilterParameters
    {
        public static bool CheckParameters(FilmListParametersServiceDto parameters)
        {
            return (CheckGenres(parameters) || CheckCountries(parameters) || CheckSearch(parameters));
        }

        private static bool CheckGenres(FilmListParametersServiceDto parameters)
        {
            return parameters.Genres.Any();
        }

        private static bool CheckCountries(FilmListParametersServiceDto parameters)
        {
            return parameters.Countries.Any();
        }

        private static bool CheckSearch(FilmListParametersServiceDto parameters)
        {
            return !string.IsNullOrWhiteSpace(parameters.QuerySearch);
        }
    }
}
