using FilmWebProject.Core.ViewModels;
using System.Collections.Generic;

namespace FilmWebProject.Core.Models
{
    public class Genre
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Film> Films { get; set; }

        public static List<Genre> GetSelectedGenres(List<GenreViewModel> viewModelGenre)
        {
            var selectedGenresFromViewModel = new List<Genre>();

            foreach (var genreViewModel in viewModelGenre)
                if (genreViewModel.IsChecked)
                    selectedGenresFromViewModel.Add(new Genre
                    {
                        Id = genreViewModel.GenreId,
                        Name = genreViewModel.Name
                    });

            return selectedGenresFromViewModel;
        }
    }
}