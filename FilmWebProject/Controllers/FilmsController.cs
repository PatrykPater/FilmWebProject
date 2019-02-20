using FilmWebProject.Core.Models;
using FilmWebProject.Core.ViewModels;
using FilmWebProject.Persistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace FilmWebProject.Controllers
{
    public class FilmsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FilmsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var genres = _context.Genres.ToList();
            var genreViewModel = new List<GenreViewModel>();

            genres.ForEach(g =>
            {
                genreViewModel.Add(new GenreViewModel
                {
                    GenreId = g.Id,
                    Name = g.Name
                });
            });

            var viewmodel = new CreateFilmFormViewModel
            {
                Genre = genreViewModel
            };

            return View(viewmodel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateFilmFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var genresInvalidModel = _context.Genres.ToList();
                var genreViewModel = new List<GenreViewModel>();

                genresInvalidModel.ForEach(g =>
                {
                    genreViewModel.Add(new GenreViewModel
                    {
                        GenreId = g.Id,
                        Name = g.Name
                    });
                });

                viewModel.Genre = genreViewModel;
                return View("Create", viewModel);
            }

            var genresFromViewModel = new List<Genre>();

            foreach (var genreViewModel in viewModel.Genre)
            {
                if (genreViewModel.IsChecked)
                {
                    genresFromViewModel.Add(new Genre
                    {
                        Id = genreViewModel.GenreId,
                        Name = genreViewModel.Name
                    });
                }
            }

            var genres = new List<Genre>();

            foreach (var genre in genresFromViewModel)
            {
                genres = _context.Genres.Where(g => g.Id == genre.Id).ToList();
            }


            var newFilm = new Film()
            {
                Title = viewModel.Title,
                Duration = TimeSpan.Parse(viewModel.Duration),
                Release = DateTime.Parse(viewModel.ReleaseDate),
                BoxOffice = decimal.Parse(viewModel.BoxOffice),
                Genres = genres,
                Budget = decimal.Parse(viewModel.Budget),
                Studio = viewModel.Studio
            };

            _context.Films.Add(newFilm);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult List()
        {
            var films = _context.Films
                .Include(f => f.Genres)
                .ToList();

            var filmsViewModel = new List<FilmListViewModel>();

            films.ForEach(f => filmsViewModel.Add(
                new FilmListViewModel
                {
                    Title = f.Title,
                    Duration = f.Duration,
                    ShortDescription = f.ShortDescription,
                    Production = f.Production,
                    Release = f.Release.ToString("dd MMMM yyyy"),
                    Budget = f.Budget.ToString("C"),
                    Score = f.Score,
                    Studio = f.Studio,
                    BoxOffice = f.BoxOffice.ToString("C"),
                    Genres = f.Genres
                }));

            return View(filmsViewModel);
        }


        public ActionResult Details()
        {


            return View();
        }
    }
}