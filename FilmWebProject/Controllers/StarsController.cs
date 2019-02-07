using FilmWebProject.Core.Models;
using FilmWebProject.Core.ViewModels;
using FilmWebProject.Persistence;
using System.Web.Mvc;

namespace FilmWebProject.Controllers
{
    public class StarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StarsController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Create()
        {
            ViewBag.ControllerName = "Stars";
            ViewBag.RoleType = "Star";

            var viewModel = new CreatePersonFormViewModel();

            return View("CreatePersonView", viewModel);
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(CreatePersonFormViewModel viewModel)
        {

            var newStar = new Star()
            {
                FirstName = viewModel.FirstName,
                LastName = viewModel.LastName,
                DateOfBirth = viewModel.DateOfBirth,
                PlaceOfBirth = viewModel.PlaceOfBirth,
                Height = viewModel.Height
            };

            _context.Stars.Add(newStar);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }
    }
}