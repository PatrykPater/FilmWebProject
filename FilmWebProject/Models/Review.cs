using System;
using System.Collections.Generic;

namespace FilmWebProject.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime? DateOfPublication { get; set; }
        public string Content { get; set; }
        public double Score { get; set; }
        public List<string> Comment { get; set; }

        public ApplicationUser Author { get; set; }
        public Film ReviewedFilm { get; set; }
    }
}