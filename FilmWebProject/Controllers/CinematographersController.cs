using FilmWebProject.Core.Models;
using FilmWebProject.Core.ViewModels;
using FilmWebProject.Persistence;
using System.Linq;
using System.Web.Mvc;

namespace FilmWebProject.Controllers
{
    public class CinematographersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CinematographersController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            ViewBag.ControllerName = "Photographers";
            ViewBag.RoleType = "Cinematographer";

            var viewModel = new CreatePersonFormViewModel();

            return View("CreatePersonView", viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(CreatePersonFormViewModel viewModel)
        {

            var newCinematographer = new Cinematographer()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                DateOfBirth = viewModel.DateOfBirth,
                PlaceOfBirth = viewModel.PlaceOfBirth,
                Height = viewModel.Height
            };

            _context.Cinematographers.Add(newCinematographer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult List()
        {
            var cinematographerList = _context.Cinematographers.ToList();
            var viewModel = new CinematographersListViewModel() { CinematographerList = cinematographerList };

            return View(viewModel);
        }
    }
}