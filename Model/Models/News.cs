using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model.Models
{
    public class News
    {
        public News()
        {
            Tags = new List<NewsTags>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateOfPublication { get; set; }

        public ICollection<NewsTags> Tags { get; set; }
        public ApplicationUser Author { get; set; }
    }
}
