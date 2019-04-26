using Data.Infrastructure;
using Model.Models;

namespace Service
{
    public class ReviewService : ServiceBase, IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ReviewService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddReview(Review review)
        {
            _unitOfWork.Reviews.Add(review);
        }
    }
}
