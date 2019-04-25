using AutoMapper;
using Service;
using System.Net;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;
        private readonly IManagerService _managerService;

        public AdminController(IUserService userService, IManagerService managerService)
        {
            _userService = userService;
            _managerService = managerService;
        }

        public ActionResult Panel()
        {
            return View();
        }

        public ActionResult AddModerator(string email = null)
        {
            if (!string.IsNullOrWhiteSpace(email))
            {
                var userToMod = _userService.GetUserByEmail(email);
                var userToModViewModel = Mapper.Map<AdminPromoteToModViewModel>(userToMod);
                userToModViewModel.IsSearched = true;

                if (_managerService.IsModded(userToMod.Id))
                    userToModViewModel.IsPromoted = true;

                return View(userToModViewModel);
            }

            var viewModel = new AdminPromoteToModViewModel();

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Search(string email)
        {
            return RedirectToAction("AddModerator", "Admin", new { email });
        }

        public ActionResult Promote(string userId)
        {
            var result = _managerService.PromoteToMod(userId);

            if (!result)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var user = _userService.GetUserById(userId);
            var userViewModel = Mapper.Map<AdminPromoteToModViewModel>(user);

            return RedirectToAction("AddModerator", "Admin", userViewModel);
        }
    }
}