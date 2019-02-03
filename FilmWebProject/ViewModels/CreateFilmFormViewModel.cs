using FilmWebProject.Models;
using System;
using System.Collections.Generic;

namespace FilmWebProject.ViewModels
{
    public class CreateFilmFormViewModel
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string ShortDescription { get; set; }
        public string Production { get; set; }
        public DateTime ReleaseDate { get; set; }
        public Genre Genre { get; set; }
        public string Director { get; set; }
        public string Scriptwriter { get; set; }
        public IEnumerable<Genre> Genres { get; set; }
    }
}