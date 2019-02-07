using FilmWebProject.Core.Models;
using FilmWebProject.Core.ViewModels;
using FilmWebProject.Persistence;
using System.Linq;
using System.Web.Mvc;

namespace FilmWebProject.Controllers
{
    public class DirectorsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DirectorsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ControllerName = "Directors";
            ViewBag.RoleType = "Director";

            var viewModel = new CreatePersonFormViewModel();

            return View("CreatePersonView", viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(CreatePersonFormViewModel viewModel)
        {
            var newDirector = new Director()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                DateOfBirth = viewModel.DateOfBirth,
                PlaceOfBirth = viewModel.PlaceOfBirth,
                Height = viewModel.Height
            };

            _context.Directors.Add(newDirector);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult List()
        {
            var directorsList = _context.Directors.ToList();
            var viewModel = new DirectorsListViewModel() { DirectorsList = directorsList };

            return View(viewModel);
        }
    }
}