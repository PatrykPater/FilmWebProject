using System.Web.Mvc;

namespace Web.Controllers
{
    public class NewsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}