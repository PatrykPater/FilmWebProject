using FilmWebProject.Core.Models;
using FilmWebProject.Core.ViewModels;
using FilmWebProject.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace FilmWebProject.Core.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Genre> GetAllGenres()
        {
            return _context.Genres.ToList();
        }

        public List<Genre> GetSelectedGenres(FilmFormViewModel viewModel)
        {
            var listOfSelectedGenres = new List<Genre>();

            foreach (var genreViewModel in viewModel.Genres)
                if (genreViewModel.IsChecked)
                    listOfSelectedGenres.Add(_context.Genres.Single(g => g.Id == genreViewModel.Id));

            return listOfSelectedGenres;
        }
    }
}