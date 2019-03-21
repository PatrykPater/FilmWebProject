using System.Collections.Generic;

namespace Model.Models
{
    public class Genre
    {
        public Genre()
        {
            Films = new List<Film>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Film> Films { get; set; }
    }
}