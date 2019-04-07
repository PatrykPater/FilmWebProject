using Data.Infrastructure;
using Model.Models;

namespace Data.Repositories
{
    public class PersonRepository : RepositoryBase<Person>, IPersonRepository
    {
        public PersonRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
