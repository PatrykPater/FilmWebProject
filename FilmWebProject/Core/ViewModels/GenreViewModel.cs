using FilmWebProject.Core.Models;
using System.Collections.Generic;

namespace FilmWebProject.Core.ViewModels
{
    public class GenreViewModel
    {
        public int GenreId { get; set; }
        public string Name { get; set; }
        public bool IsChecked { get; set; }

        public static List<GenreViewModel> GetGenresForViewModel(List<Genre> genres)
        {
            var genreViewModel = new List<GenreViewModel>();

            genres.ForEach(g =>
            {
                genreViewModel.Add(new GenreViewModel
                {
                    GenreId = g.Id,
                    Name = g.Name
                });
            });
            return genreViewModel;
        }

    }
}