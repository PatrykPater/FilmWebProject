using System.Collections.Generic;
using FilmWebProject.Core.Models;
using FilmWebProject.Core.ViewModels;

namespace FilmWebProject.Core.Repositories
{
    public interface IGenreRepository
    {
        List<Genre> GetAllGenres();
        List<Genre> GetSelectedGenres(FilmFormViewModel viewModel);
    }
}