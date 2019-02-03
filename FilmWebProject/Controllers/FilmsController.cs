using FilmWebProject.Models;
using FilmWebProject.ViewModels;
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

        public ActionResult Create()
        {
            var genres = _context.Genres.ToList();

            var viewmodel = new CreateFilmFormViewModel
            {
                Genres = genres
            };

            return View(viewmodel);
        }
    }
}