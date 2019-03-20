using Model.Models;
using System.Collections.Generic;

namespace Web.ViewModels
{
    public class FilmListViewModel
    {
        public IEnumerable<Film> ListOfFilms { get; set; }
        public string Search { get; set; }
    }
}