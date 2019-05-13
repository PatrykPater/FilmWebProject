using AutoMapper;
using Model.Models;
using Service;
using System.Collections.Generic;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsService _newsService;

        public HomeController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public ActionResult Index()
        {
            var newsFromRepo = _newsService.GetAllNews();
            var viewModel = Mapper.Map<IEnumerable<News>, IEnumerable<NewsForMainPageViewModel>>(newsFromRepo);

            return View(viewModel);
        }
    }
}