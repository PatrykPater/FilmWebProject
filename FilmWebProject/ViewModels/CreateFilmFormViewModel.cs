using FilmWebProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmWebProject.ViewModels
{
    public class CreateFilmFormViewModel
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string Production { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        [ReleaseDateValidation]
        public string ReleaseDate { get; set; }

        public Genre Genre { get; set; }
        public string Director { get; set; }
        public string Scriptwriter { get; set; }
        public double BoxOffice { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }

}