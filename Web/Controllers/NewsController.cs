using AutoMapper;
using Service;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var news = _newsService.GetNewsById(id);

            if (news == null)
                return HttpNotFound();

            var newsViewmodel = Mapper.Map<NewsDetailsViewModel>(news);

            return View(newsViewmodel);
        }
    }
}