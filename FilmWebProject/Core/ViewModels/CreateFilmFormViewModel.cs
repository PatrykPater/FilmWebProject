using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmWebProject.Core.ViewModels
{
    public class CreateFilmFormViewModel
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string Production { get; set; }
        public decimal Budget { get; set; }
        public string Studio { get; set; }
        public decimal BoxOffice { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public List<GenreViewModel> Genre { get; set; }
    }

}