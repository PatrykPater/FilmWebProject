using Data.Infrastructure;
using Model.Models;

namespace Data.Repositories
{
    public interface IRatingRepository : IRepository<Rating>
    {
        Rating GetUserRating(int filmId, string userId);
    }
}