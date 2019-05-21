using System.Collections.Generic;

namespace Service.Dtos
{
    public class FilmListParametersDto
    {
        public FilmListParametersDto()
        {
            Genres = new List<string>();
            Countries = new List<string>();
        }

        public string QuerySearch { get; set; } = null;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 5;
        public int MaxPageNumber { get; set; }
        public int CurrentPage { get; set; } = 1;
        public List<string> Genres { get; set; }
        public List<string> Countries { get; set; }

    }
}