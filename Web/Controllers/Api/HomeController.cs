using Service;
using System.Collections.Generic;
using System.Linq;
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
        public IEnumerable<NewsDto> Get()
        {
            var news = _newsService.GetAllNews()
                .Select(n => _dtoFactory.CreateNewsDto(n));

            return news;
        }
    }
}
