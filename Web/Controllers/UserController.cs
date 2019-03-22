using Service;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult List(string query = null)
        {
            var users = _userService.GetAllUsers();
            var viewModel = new UserListViewModel();

            if (!string.IsNullOrWhiteSpace(query))
            {
                users = _userService.GetUsersByQuery(users, query);
                viewModel.IsSearched = true;
            }

            viewModel.Users = users;

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Search(UserListViewModel viewModel)
        {
            return RedirectToAction("List", "User", new { query = viewModel.Query });
        }
    }
}