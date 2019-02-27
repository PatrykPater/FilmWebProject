using FilmWebProject.Core.ViewModels;
using System;
using System.Collections.Generic;

namespace FilmWebProject.Core.Models
{
    public class Film
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }
        public string Production { get; set; }
        public DateTime Release { get; set; }
        public decimal Budget { get; set; }
        public double Score { get; set; }
        public string Studio { get; set; }
        public decimal BoxOffice { get; set; }

        public ICollection<Genre> Genres { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Trailer> Trailers { get; set; }

        public void Update(List<Genre> genres, FilmFormViewModel viewModel)
        {

            BoxOffice = viewModel.BoxOffice;
            Budget = viewModel.Budget;
            Duration = viewModel.Duration;
            Genres = genres;
            Production = viewModel.Production;
            Release = Convert.ToDateTime(viewModel.Release);
            Studio = viewModel.Studio;
            Title = viewModel.Title;
        }
    }
}