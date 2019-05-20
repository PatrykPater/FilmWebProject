using System;
using System.Collections.Generic;
using System.Linq;

namespace Model.Models
{
    public class Film
    {
        public Film()
        {
            Ratings = new List<Rating>();
            Genres = new List<Genre>();
            Reviews = new List<Review>();
            Trailers = new List<Trailer>();
            Country = new List<Country>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public DateTime Release { get; set; }
        public decimal Budget { get; set; }
        public string Studio { get; set; }
        public decimal BoxOffice { get; set; }

        public int RatingsNumber => Ratings.Count();
        public double Score => Ratings.Any() ? Ratings.Average(r => r.Value) : 0;

        public ICollection<Country> Country { get; set; }
        public ICollection<Rating> Ratings { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Trailer> Trailers { get; set; }
    }
}