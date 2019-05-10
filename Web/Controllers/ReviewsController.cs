using Service;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    [Authorize]
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public ActionResult AddReview()
        {
            var viewModel = new ReviewForFormViewModel();
            return View(viewModel);
        }
    }
}