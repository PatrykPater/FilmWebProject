using Service;
using System.Collections.Generic;
using System.Web.Http;
using Web.Dtos;

namespace Web.Controllers.Api
{
    public class HomeController : ApiController
    {
        private readonly INewsService _newsService;
        private readonly IDtoFactory _dtoFactory;

        public HomeController(INewsService newsService, IDtoFactory dtoFactory)
        {
            _newsService = newsService;
            _dtoFactory = dtoFactory;
        }

        [HttpGet]
        public ICollection<NewsDto> Get()
        {
            var news = _newsService.GetAllNews();

            return _dtoFactory.CreateNewsDto(news);
        }
    }
}
