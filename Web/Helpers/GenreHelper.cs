using Data.Infrastructure;
using Model.Models;
using System.Collections.Generic;
using Web.ViewModels;

namespace Web.Helpers
{
    public class GenreHelper : IGenreHelper
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenreHelper(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Genre> GetSelectedGenres(FilmFormViewModel viewModel)
        {
            var listOfSelectedGenres = new List<Genre>();

            foreach (var genreViewModel in viewModel.Genres)
                if (genreViewModel.IsChecked)
                    listOfSelectedGenres.Add(_unitOfWork.Genres.GetGenreById(genreViewModel.Id));

            return listOfSelectedGenres;
        }

        public List<GenreViewModel> GetAllAndSelectedGenres(List<GenreViewModel> genresViewModel, ICollection<Genre> currentFilmGenres)
        {
            foreach (var genreViewModel in genresViewModel)
                foreach (var currentFilmGenre in currentFilmGenres)
                    if (currentFilmGenre.Id == genreViewModel.Id)
                        genreViewModel.IsChecked = true;

            return genresViewModel;
        }
    }
}