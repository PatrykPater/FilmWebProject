using Model.Models;
using System;
using System.Collections.Generic;

namespace Web.ViewModels
{
    public class NewsForMainPageViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string ShortDescription { get; set; }
        public DateTime DateOfPublication { get; set; }

        public ICollection<NewsTags> Tags { get; set; }
        public ApplicationUser Author { get; set; }
    }
}