using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult SearchUser(string query = null)
        {
            var viewModel = new SearchUserViewModel();

            return View(viewModel);
        }
    }
}