using FilmWebProject.Persistence;

namespace FilmWebProject.Core.Repositories
{
    public class FilmRepository
    {
        private readonly ApplicationDbContext _context;

        public FilmRepository(ApplicationDbContext context)
        {
            _context = context;
        }
    }
}