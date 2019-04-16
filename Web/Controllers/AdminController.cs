using System.Net;
using System.Web.Mvc;

namespace Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        public ActionResult Panel()
        {
            var user = User.IsInRole("Admin");

            if (!user)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "You are not authorized to access this page");

            return View();
        }

        public ActionResult AddModerator(string email = null)
        {
            var user = User.IsInRole("Admin");

            if (!user)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "You are not authorized to access this page");

            return View();
        }

        [HttpPost]
        public ActionResult Search(string email)
        {

            return RedirectToAction("AddModerator", "Admin", new { email });
        }
    }
}