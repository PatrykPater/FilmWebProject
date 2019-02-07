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
            var genre = _context.Genres.Single(g => g.Id == viewModel.Genre);

            var lastAndFirstNameScriptwriter = viewModel.Scriptwriter.Split();

            var newScriptwriter = new Scriptwriter()
            {
                FirstName = lastAndFirstNameScriptwriter[0],
                LastName = lastAndFirstNameScriptwriter[1]
            };

            var lastAndFirstNameDirector = viewModel.Director.Split();

            var newDirector = new Director()
            {
                FirstName = lastAndFirstNameDirector[0],
                LastName = lastAndFirstNameDirector[1]
            };

            var newFilm = new Film()
            {
                Title = viewModel.Title,
                Duration = viewModel.Duration,
                Director = newDirector,
                Scriptwriter = newScriptwriter,
                Genre = genre,
                Production = viewModel.Production,
                Release = viewModel.ReleaseDate,
                BoxOffice = viewModel.BoxOffice
            };

            _context.Films.Add(newFilm);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}