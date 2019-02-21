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

            var viewmodel = new FilmFormViewModel
            {
                Genre = genreViewModel
            };

            return View("FilmForm", viewmodel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FilmFormViewModel viewModel)
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
                return View("FilmForm", viewModel);
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
                    Id = f.Id,
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


        public ActionResult Details(int id)
        {
            var film = _context.Films
                .Include(f => f.Genres)
                .Single(f => f.Id == id);

            if (film == null)
                return HttpNotFound();

            return View(film);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            var film = _context.Films
                .Include(f => f.Genres)
                .Single(f => f.Id == id);

            var genresDb = _context.Genres.ToList();

            if (film == null)
                return HttpNotFound();

            var genres = new List<GenreViewModel>();

            foreach (var genre in genresDb)
            {
                genres.Add(new GenreViewModel
                {
                    Name = genre.Name,
                    GenreId = genre.Id,
                });
            }

            foreach (var genre in genres)
            {
                foreach (var genreDb in film.Genres)
                {
                    if (genreDb.Id == genre.GenreId)
                    {
                        genre.IsChecked = true;
                    }
                }
            }

            var filmCreateFormViewModel = new FilmFormViewModel
            {
                Title = film.Title,
                BoxOffice = film.BoxOffice.ToString("C"),
                Budget = film.Budget.ToString("C"),
                Duration = film.Duration.ToString(),
                Genre = genres,
                Production = film.Production,
                ReleaseDate = film.Release.ToString("dd MMMM yyyy"),
                Studio = film.Studio
            };

            return View("FilmForm", filmCreateFormViewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Update(FilmFormViewModel viewModel)
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
                return View("FilmForm", viewModel);
            }

            var filmFromDb = _context.Films
                .Single(f => f.Id == viewModel.Id);

            if (filmFromDb == null)
                return HttpNotFound();

            var genre = new List<Genre>();

            foreach (var genreViewModel in viewModel.Genre)
            {
                genre.Add(new Genre
                {
                    Name = genreViewModel.Name,
                    Id = genreViewModel.GenreId
                });
            }

            filmFromDb.BoxOffice = Convert.ToDecimal(viewModel.BoxOffice);
            filmFromDb.Budget = Convert.ToDecimal(viewModel.Budget);
            filmFromDb.Duration = TimeSpan.Parse(viewModel.Duration);
            filmFromDb.Genres = genre;
            filmFromDb.Production = viewModel.Production;
            filmFromDb.Release = Convert.ToDateTime(viewModel.ReleaseDate);
            filmFromDb.Studio = viewModel.Studio;
            filmFromDb.Title = viewModel.Title;

            _context.SaveChanges();

            return RedirectToAction("Details");
        }
    }
}