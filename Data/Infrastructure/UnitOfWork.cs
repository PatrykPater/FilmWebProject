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
        public INotificationRepository Notifications { get; }
        public IAwardRepository Awards { get; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Films = new FilmRepository(_context);
            Genres = new GenreRepository(_context);
            Users = new UserRepository(_context);
            Ratings = new RatingRepository(_context);
            Notifications = new NotificationRepository(_context);
            Awards = new AwardRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}