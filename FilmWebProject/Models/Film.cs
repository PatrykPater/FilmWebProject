using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmWebProject.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Production { get; set; }
        public DateTime Release { get; set; }
        public double Budget { get; set; }
        public double Score { get; set; }
        public Genre Genre { get; set; }
        public List<Cast> Cast { get; set; }
        public Composer Music { get; set; }
        public Director Director { get; set; }
        public Photographer Photography { get; set; }
        public Scriptwriter Scriptwriter { get; set; }
        public List<Reward> Rewards { get; set; }
        public List<Review> Reviews { get; set; }
        public string Studio { get; set; }
    }
}