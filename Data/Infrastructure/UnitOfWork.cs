using Data.Repositories;

namespace Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IFilmRepository Films { get; private set; }
        public IGenreRepository Genres { get; private set; }
        public IUserRepository Users { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Films = new FilmRepository(_context);
            Genres = new GenreRepository(_context);
            Users = new UserRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}