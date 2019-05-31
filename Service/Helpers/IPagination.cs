using System.Collections.Generic;
using Model.Models;
using Service.Dtos;

namespace Service.Helpers
{
    public interface IPagination
    {
        List<Film> PerformPagination(List<Film> films, FilmListServiceDto parameters);
    }
}