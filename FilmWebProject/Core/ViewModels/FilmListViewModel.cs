using FilmWebProject.Core.Models;
using System.Collections.Generic;

namespace FilmWebProject.Core.ViewModels
{
    public class FilmListViewModel
    {
        public IEnumerable<Film> ListOfFilms { get; set; }
        public string Search { get; set; }
    }
}