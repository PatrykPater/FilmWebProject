using System;

namespace FilmWebProject.Core.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateOfPublication { get; set; }
        public string Content { get; set; }
        public ApplicationUser Author { get; set; }
        public Film Film { get; set; }

        //public List<string> Comment { get; set; }
    }
}