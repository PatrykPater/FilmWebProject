using Data.Repositories;

namespace Data.Infrastructure
{
    public interface IUnitOfWork
    {
        IFilmRepository Films { get; }
        IGenreRepository Genres { get; }
        IUserRepository Users { get; }
        IRatingRepository Ratings { get; set; }
        INotificationRepository Notifications { get; }

        void Complete();
    }
}