using System.Collections.Generic;

namespace Web.ViewModels
{
    public class NewsDetailsViewModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string DateOfPublication { get; set; }

        public IEnumerable<string> Tags { get; set; }
        public string Author { get; set; }
    }
}