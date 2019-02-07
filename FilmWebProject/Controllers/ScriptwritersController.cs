using FilmWebProject.Core.Models;
using FilmWebProject.Core.ViewModels;
using FilmWebProject.Persistence;
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
            ViewBag.RoleType = "Scriptwriter";

            var viewModel = new CreatePersonFormViewModel();

            return View("CreatePersonView", viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(CreatePersonFormViewModel viewModel)
        {

            var newScriptwriter = new Scriptwriter()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                DateOfBirth = viewModel.DateOfBirth,
                PlaceOfBirth = viewModel.PlaceOfBirth,
                Height = viewModel.Height
            };

            _context.Scriptwriters.Add(newScriptwriter);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}