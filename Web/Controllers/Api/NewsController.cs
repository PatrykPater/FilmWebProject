using Service;
using System.Linq;
using System.Web.Http;
using Web.Dtos;

namespace Web.Controllers.Api
{
    public class NewsController : ApiController
    {
        private readonly INewsService _newsService;
        private readonly IDtoFactory _dtoFactory;

        public NewsController(INewsService newsService, IDtoFactory dtoFactory)
        {
            _newsService = newsService;
            _dtoFactory = dtoFactory;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var news = _newsService.GetAllNews()
                .Select(n => _dtoFactory.CreateNewsDto(n))
                .ToList();

            return Ok(news);
        }
    }
}
