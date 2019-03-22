using Data.Repositories;

namespace Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IFilmRepository Films { get; }
        public IGenreRepository Genres { get; }
        public IUserRepository Users { get; }
        public IRatingRepository Ratings { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Films = new FilmRepository(_context);
            Genres = new GenreRepository(_context);
            Users = new UserRepository(_context);
            Ratings = new RatingRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}