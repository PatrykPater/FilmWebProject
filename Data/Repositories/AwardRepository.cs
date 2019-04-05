using Data.Infrastructure;
using Model.Models;

namespace Data.Repositories
{
    public class AwardRepository : RepositoryBase<Award>, IAwardRepository
    {
        public AwardRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
