using System.Collections.Generic;

namespace FilmWebProject.Core.Models
{
    public class Score
    {
        public int Id { get; set; }
        public double Value { get; set; }
        public List<int> Ratings { get; set; }

        public Film Film { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}