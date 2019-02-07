using FilmWebProject.Core.ViewModels;
using FilmWebProject.Persistance;
using System.Web.Mvc;

namespace FilmWebProject.Controllers
{
    public class ScriptwritersController : Controller
    {
        private ApplicationDbContext _context;

        public ScriptwritersController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ControllerName = "Scriptwriters";

            var viewModel = new CreatePersonFormViewModel();

            return View("CreatePersonView", viewModel);
        }
    }
}