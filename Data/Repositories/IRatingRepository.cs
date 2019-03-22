using Model.Models;

namespace Data.Repositories
{
    public interface IRatingRepository
    {
        Rating GetUserRating(int filmId, string userId);
        void AddNewRating(Rating newRating);
    }
}