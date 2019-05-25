using System.Collections.Generic;

namespace Service.Dtos
{
    public class FilmFormServiceDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<GenreServiceDto> Genres { get; set; }
    }
}
