using Model.Models;

namespace Web.Dtos
{
    public class ReviewToAddDto
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public UserDto Author { get; set; }
        public Film Film { get; set; }
    }
}