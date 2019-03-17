using Castle.Core.Internal;
using System.Collections.Generic;
using System.Linq;

namespace FilmWebProject.Core.Models
{
    public class Score
    {
        public int Id { get; set; }

        private double value;

        public double Value
        {
            get => value;
            set
            {
                if (Ratings.IsNullOrEmpty())
                {
                    this.value = value;
                }
                else
                {
                    this.value = Ratings.Average(r => r.Value);
                }
            }

        }

        public Film Film { get; set; }

        public ICollection<Rating> Ratings { get; set; }

        public Score()
        {
            Ratings = new List<Rating>();
        }
    }
}