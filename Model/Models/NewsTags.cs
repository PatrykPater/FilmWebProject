using System.Collections.Generic;

namespace Model.Models
{
    public class NewsTags
    {
        public NewsTags()
        {
            News = new List<News>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<News> News { get; set; }
    }
}