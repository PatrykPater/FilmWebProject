using System.Collections.Generic;

namespace Service.Dtos
{
    public class FilmFormDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<GenreDto> Genres { get; set; }
    }
}
