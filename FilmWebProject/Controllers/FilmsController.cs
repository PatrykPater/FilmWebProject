using FilmWebProject.Core.Models;
using FilmWebProject.Core.ViewModels;
using FilmWebProject.Persistence;
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

            var viewmodel = new CreateFilmFormViewModel
            {
                Genres = genres
            };

            return View(viewmodel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(CreateFilmFormViewModel viewModel)
        {
            var genre = _context.Genres.Where(c => c.Id == viewModel.GenreId).ToList();

            var newFilm = new Film()
            {
                Title = viewModel.Title,
                Duration = viewModel.Duration,
                Release = viewModel.ReleaseDate,
                BoxOffice = viewModel.BoxOffice,
                Genre = genre
            };

            _context.Films.Add(newFilm);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}