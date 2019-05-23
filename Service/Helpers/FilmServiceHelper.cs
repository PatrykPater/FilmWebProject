using Service.Dtos;
using System.Linq;

namespace Service.Helpers
{
    public class FilmServiceHelper
    {
        public bool IsSearched(FilmListParametersDto parameters)
        {
            return !parameters.Genres.Any() && !parameters.Countries.Any() &&
                   string.IsNullOrWhiteSpace(parameters.QuerySearch);
        }
    }
}
