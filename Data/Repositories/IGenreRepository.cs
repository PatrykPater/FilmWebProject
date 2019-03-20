using System.Collections.Generic;
using Model.Models;

namespace Data.Repositories
{
    public interface IGenreRepository
    {
        List<Genre> GetAllGenres();
        List<Genre> GetSelectedGenres(FilmFormViewModel viewModel);
    }
}