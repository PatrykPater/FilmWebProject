using Model.Models;
using System.Collections.Generic;

namespace Web.ViewModels
{
    public class FilmListViewModel
    {
        public FilmListViewModel()
        {
            ListOfFilms = new List<Film>();
            FilmListParameters = new FilmListParametersPostedViewModel();
            Genres = new List<GenreViewModel>();
            CountryList = new List<CountryFilterViewModel>();
        }

        public IEnumerable<Film> ListOfFilms { get; set; }
        public FilmListParametersPostedViewModel FilmListParameters { get; set; }
        public List<GenreViewModel> Genres { get; set; }
        public List<CountryFilterViewModel> CountryList { get; set; }
    }
}