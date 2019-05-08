using Microsoft.AspNet.Identity;
using Service;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;
        private readonly IModelFactory _modelFactory;

        public UsersController(IUserService userService, IModelFactory modelFactory)
        {
            _userService = userService;
            _modelFactory = modelFactory;
        }

        public ActionResult List(string query = null)
        {
            if (!string.IsNullOrWhiteSpace(query))
            {
                var userid = User.Identity.GetUserId();
                var currentUser = _userService.GetUserById(userid);
                var users = _userService.GetUsersByQuery(query);

                return View(_modelFactory.Create(currentUser, users));
            }

            return View(_modelFactory.Create());
        }

        [HttpPost]
        public ActionResult Search(UserListViewModel viewModel)
        {
            return RedirectToAction("List", "Users", new { query = viewModel.Query });
        }
    }
}