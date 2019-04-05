using Data.Infrastructure;
using Model.Models;
using System.Linq;

namespace Data.Repositories
{
    public class RatingRepository : RepositoryBase<Rating>, IRatingRepository
    {
        private readonly ApplicationDbContext _context;

        public RatingRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public Rating GetUserRating(int filmId, string userId)
        {
            return _context.Ratings
                .SingleOrDefault(r => r.Film.Id == filmId && r.User.Id == userId);
        }
    }
}
