using Data.Helpers;
using Model.Models;
using System.Collections.Generic;

namespace Web.ViewModels
{
    public class FilmListViewModel
    {
        public FilmListViewModel()
        {
            ListOfFilms = new List<Film>();
            FilmListParameters = new FilmListParameters();
        }

        public IEnumerable<Film> ListOfFilms { get; set; }
        //public string Search { get; set; }
        public FilmListParameters FilmListParameters { get; set; }
    }
}