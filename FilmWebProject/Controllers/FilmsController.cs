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

            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}