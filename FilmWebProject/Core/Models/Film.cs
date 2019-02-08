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
        public List<int?> GenreId { get; set; }
        public List<Genre> Genre { get; set; }

        [ForeignKey("Cast")]
        public List<int?> CastId { get; set; }
        public List<Person> Cast { get; set; }

        [ForeignKey("Crew")]
        public List<int?> CrewId { get; set; }
        public List<Person> Crew { get; set; }

    }
}