using System.Collections.Generic;

namespace Web.ViewModels
{
    public class FilmListParametersPostedViewModel
    {
        public FilmListParametersPostedViewModel()
        {
            Genres = new List<GenreViewModel>();
            Countries = new List<CountryFilterViewModel>();
        }

        public string QuerySearch { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public int MaxPageNumber { get; set; }
        public int CurrentPage { get; set; } = 1;
        public List<GenreViewModel> Genres { get; set; }
        public List<CountryFilterViewModel> Countries { get; set; }
    }
}