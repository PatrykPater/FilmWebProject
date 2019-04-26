using AutoMapper;
using Model.Models;
using Service;
using System.Net;
using System.Web.Http;
using Web.Dtos;

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
        public IHttpActionResult AddReview(ReviewToAddDto reviewDto)
        {
            if (!ModelState.IsValid)
                return StatusCode(HttpStatusCode.BadRequest);

            var review = Mapper.Map<Review>(reviewDto);

            _reviewService.AddReview(review);
            _reviewService.Complete();

            return Ok();
        }
    }
}
