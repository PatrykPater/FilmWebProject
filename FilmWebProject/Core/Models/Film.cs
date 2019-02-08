using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmWebProject.Core.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Production { get; set; }

        public DateTime Release { get; set; }
        public double Budget { get; set; }
        public double Score { get; set; }
        public string Studio { get; set; }
        public double BoxOffice { get; set; }

        [ForeignKey("Genre")]
        public int? GenreId { get; set; }
        public Genre Genre { get; set; }

        public List<Star> Cast { get; set; }
        public Composer Music { get; set; }
        public Director Director { get; set; }
        public Cinematographer Cinematography { get; set; }
        public Scriptwriter Scriptwriter { get; set; }
        public List<Reward> Rewards { get; set; }
        public List<Review> Reviews { get; set; }

    }
}