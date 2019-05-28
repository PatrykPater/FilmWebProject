using System.Collections.Generic;

namespace Service.Dtos
{
    public class FilmListParametersServiceDto
    {
        public FilmListParametersServiceDto()
        {
            Genres = new List<GenreServiceDto>();
            Countries = new List<CountryServiceDto>();
        }

        public string QuerySearch { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public int MaxPageNumber { get; set; }
        public int CurrentPage { get; set; } = 1;
        public List<GenreServiceDto> Genres { get; set; }
        public List<CountryServiceDto> Countries { get; set; }

    }
}