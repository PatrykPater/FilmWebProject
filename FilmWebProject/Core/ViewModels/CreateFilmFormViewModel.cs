using FilmWebProject.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmWebProject.Core.ViewModels
{
    public class CreateFilmFormViewModel
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string Production { get; set; }
        public double Budget { get; set; }
        public double Score { get; set; }
        public string Studio { get; set; }
        public double BoxOffice { get; set; }

        [Display(Name = "Release Date")]
        public DateTime ReleaseDate { get; set; }

        public IEnumerable<Genre> Genres { get; set; }
        public int GenreId { get; set; }
        public bool IsGenre { get; set; }

        //public IEnumerable<int> CastId { get; set; }
        //public IEnumerable<Person> Cast { get; set; }

        //public List<int> CrewId { get; set; }
        //public IEnumerable<Person> Crew { get; set; }


    }

}