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

            if (!string.IsNullOrWhiteSpace(query))
                users = _userService.GetUsersByQuery(users, query);

            var viewModel = new UserListViewModel { Users = users };

            return View(viewModel);
        }
    }
}