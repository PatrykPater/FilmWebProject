using Model.Models;
using Service.Dtos;
using System.Collections.Generic;
using System.Linq;

namespace Service.Helpers
{
    public class Pagination : IPagination
    {
        public List<Film> PerformPagination(List<Film> films, FilmListServiceDto parameters)
        {
            films = films.Skip(parameters.PageSize * (parameters.PageNumber - 1)).Take(parameters.PageSize).ToList();
            return films;
        }
    }
}
