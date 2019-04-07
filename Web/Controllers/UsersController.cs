using Microsoft.AspNet.Identity;
using Service;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult List(string query = null)
        {
            var viewModel = new UserListViewModel();


            //refactor in the near future
            if (!string.IsNullOrWhiteSpace(query))
            {
                var userid = User.Identity.GetUserId();
                var user = _userService.GetUserById(userid);
                var users = _userService.GetUsersByQuery(query);

                viewModel.Users = users;
                viewModel.User = user;
                viewModel.IsSearched = true;
            }

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Search(UserListViewModel viewModel)
        {
            return RedirectToAction("List", "Users", new { query = viewModel.Query });
        }
    }
}