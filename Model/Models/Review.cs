using System;

namespace Model.Models
{
    public class Review
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime DateTime { get; set; }

        public DateTime DateOfPublication => DateTime.Now;
        public string Content { get; set; }

        public ApplicationUser Author { get; set; }
        public Film Film { get; set; }
    }
}