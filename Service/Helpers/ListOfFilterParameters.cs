using Service.Dtos;
using System.Linq;

namespace Service.Helpers
{
    public class ListOfFilterParameters
    {
        //Add additional methods to check the if statement here
        public static bool CheckParameters(FilmListServiceDto parameters)
        {
            return (CheckGenres(parameters) || CheckCountries(parameters) || CheckSearch(parameters));
        }

        private static bool CheckGenres(FilmListServiceDto parameters)
        {
            return parameters.Genres.Any();
        }

        private static bool CheckCountries(FilmListServiceDto parameters)
        {
            return parameters.Countries.Any();
        }

        private static bool CheckSearch(FilmListServiceDto parameters)
        {
            return !string.IsNullOrWhiteSpace(parameters.QuerySearch);
        }
    }
}
