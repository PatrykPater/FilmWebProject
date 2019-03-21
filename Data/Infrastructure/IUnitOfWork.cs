using Data.Repositories;

namespace Data.Infrastructure
{
    public interface IUnitOfWork
    {
        IFilmRepository Films { get; }
        IGenreRepository Genres { get; }
        IUserRepository Users { get; }

        void Complete();
    }
}