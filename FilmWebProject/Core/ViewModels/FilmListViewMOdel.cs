using FilmWebProject.Core.Models;
using System;
using System.Collections.Generic;

namespace FilmWebProject.Core.ViewModels
{
    public class FilmListViewModel
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string ShortDescription { get; set; }
        public string Production { get; set; }
        public DateTime Release { get; set; }
        public double Budget { get; set; }
        public double Score { get; set; }
        public string Studio { get; set; }
        public double BoxOffice { get; set; }
        public ICollection<Genre> Genres { get; set; }

    }
}