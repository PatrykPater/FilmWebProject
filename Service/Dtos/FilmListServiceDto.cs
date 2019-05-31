using Model.Models;
using System.Collections.Generic;

namespace Service.Dtos
{
    public class FilmListServiceDto
    {
        public FilmListServiceDto()
        {
            Genres = new List<GenreServiceDto>();
            Countries = new List<CountryServiceDto>();
            Films = new List<Film>();
        }

        public string QuerySearch { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public int MaxPageNumber { get; set; }
        public int CurrentPage { get; set; } = 1;

        public List<GenreServiceDto> Genres { get; set; }
        public List<CountryServiceDto> Countries { get; set; }

        public List<Film> Films { get; set; }

    }
}