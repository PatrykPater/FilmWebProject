using System.Collections.Generic;

namespace FilmWebProject.Core.Models
{
    public class Award
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public int Year { get; set; }
        public ICollection<Film> Film { get; set; }
    }
}