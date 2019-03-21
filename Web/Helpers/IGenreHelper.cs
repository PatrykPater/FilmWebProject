using System.Collections.Generic;
using Model.Models;
using Web.ViewModels;

namespace Web.Helpers
{
    public interface IGenreHelper
    {
        List<GenreViewModel> GetAllAndSelectedGenres(List<GenreViewModel> genresViewModel, ICollection<Genre> currentFilmGenres);
        List<Genre> GetSelectedGenres(FilmFormViewModel viewModel);
    }
}