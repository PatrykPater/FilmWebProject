using FilmWebProject.Core.Models;
using FilmWebProject.Core.ViewModels;
using FilmWebProject.Persistence;
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
            ViewBag.ControllerName = "Composers";
            ViewBag.RoleType = "Composer";

            var viewModel = new CreatePersonFormViewModel();

            return View("CreatePersonView", viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(CreatePersonFormViewModel viewModel)
        {

            var newComposer = new Composer()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                DateOfBirth = viewModel.DateOfBirth,
                PlaceOfBirth = viewModel.PlaceOfBirth,
                Height = viewModel.Height
            };

            _context.Composers.Add(newComposer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}