using System.Collections.Generic;
using Model.Models;
using Service.Dtos;

namespace Service.Helpers
{
    public interface IFilmFilter
    {
        FilmListServiceDto Filter(List<Film> films, FilmListServiceDto parameters);
    }
}