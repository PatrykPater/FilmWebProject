using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModels
{
    public class FilmFormViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Title { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        [Display(Name = "Release Date")]
        public DateTime Release { get; set; }

        [Required]
        public decimal BoxOffice { get; set; }

        [Required]
        public decimal Budget { get; set; }

        public string Production { get; set; }
        public string Studio { get; set; }

        public List<GenreViewModel> Genres { get; set; }

        public string Action => (Id != 0) ? "Update" : "Create";
    }

}