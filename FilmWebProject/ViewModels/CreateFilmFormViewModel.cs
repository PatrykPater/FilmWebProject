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

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public int Genre { get; set; }
        public string Director { get; set; }
        public string Scriptwriter { get; set; }
        public double BoxOffice { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }

}