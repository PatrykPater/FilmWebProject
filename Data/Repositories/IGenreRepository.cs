using Model.Models;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IGenreRepository
    {
        List<Genre> GetAllGenres();
        Genre GetGenreById(int id);
    }
}