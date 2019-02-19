using FilmWebProject.Core.Models;
using FilmWebProject.Core.ViewModels;
using FilmWebProject.Persistence;
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
        public ActionResult Create(CreateFilmFormViewModel viewModel)
        {
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
                Duration = viewModel.Duration,
                Release = viewModel.ReleaseDate,
                BoxOffice = viewModel.BoxOffice,
                Genres = genres,
                Budget = viewModel.Budget,
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

            return View(films);
        }
    }
}