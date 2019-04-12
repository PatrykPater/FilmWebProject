using System;
using System.Collections.Generic;

namespace Web.Dtos
{
    public class NewsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DateOfPublication { get; set; }
        public string ShortDescription { get; set; }

        public IEnumerable<NewsTagsDto> Tags { get; set; }
        public UserDto Author { get; set; }
    }
}