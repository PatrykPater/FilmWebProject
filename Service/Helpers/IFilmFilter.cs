using System.Collections.Generic;
using Model.Models;
using Service.Dtos;

namespace Service.Helpers
{
    public interface IFilmFilter
    {
        List<Film> Filter(List<Film> films, FilmListParametersServiceDto parameters);
    }
}