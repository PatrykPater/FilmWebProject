using Model.Models;
using Service;
using System.Web.Http;

namespace Web.Controllers.Api
{
    public class ReviewsController : ApiController
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost]
        public IHttpActionResult AddReview(Review review)
        {
            _reviewService.AddReview(review);

            return Ok();
        }
    }
}
