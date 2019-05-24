using Model.Models;
using System.Collections.Generic;

namespace Service.Dtos
{
    public class FilmListParametersDto
    {
        public FilmListParametersDto()
        {
            Genres = new List<Genre>();
            Countries = new List<Country>();
        }

        public string QuerySearch { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public int MaxPageNumber { get; set; }
        public int CurrentPage { get; set; } = 1;
        public List<Genre> Genres { get; set; }
        public List<Country> Countries { get; set; }

    }
}