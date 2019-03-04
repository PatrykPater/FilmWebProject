using System.Collections.Generic;
using System.Linq;

namespace FilmWebProject.Core.Models
{
    public class Score
    {
        public int Id { get; set; }

        public double Value
        {
            get => Value;
            set => Value = Ratings.Average(r => r.Value);
        }

        public Film Film { get; set; }
        public ICollection<Rating> Ratings { get; set; }
    }
}