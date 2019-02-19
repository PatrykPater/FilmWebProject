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
        public string Release { get; set; }
        public string Budget { get; set; }
        public double Score { get; set; }
        public string Studio { get; set; }
        public string BoxOffice { get; set; }
        public ICollection<Genre> Genres { get; set; }

        public static string GetDateOfRelease(DateTime date)
        {
            return date.ToString("yyyy MMMM dd"); ;
        }

        public static string GetMoneyValues(decimal value)
        {
            return value.ToString("C");
        }

    }
}