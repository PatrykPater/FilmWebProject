using FilmWebProject.Core.ViewModels;
using FilmWebProject.Persistance;
using System.Web.Mvc;

namespace FilmWebProject.Controllers
{
    public class ComposersController : Controller
    {
        private ApplicationDbContext _context;

        public ComposersController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CreatePersonFormViewModel();

            return View(viewModel);
        }
    }
}