using System;
using System.Collections.Generic;

namespace Model.Models
{
    public class News
    {
        public News()
        {
            Tags = new List<NewsTags>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public DateTime DateOfPublication { get; set; }

        public bool IsNew => DateTime.Now - DateOfPublication <= new TimeSpan(0, 23, 59, 59);

        public ICollection<NewsTags> Tags { get; set; }
        public ApplicationUser Author { get; set; }
    }
}
