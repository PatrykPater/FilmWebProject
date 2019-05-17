using Data.Helpers;
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
        IAwardRepository Awards { get; }
        IPersonRepository Persons { get; set; }
        INewsRepository News { get; set; }
        IUserManagerHelper ManagerHelper { get; set; }
        IReviewRepository Reviews { get; set; }
        ICountryRepository Countries { get; set; }

        void Complete();
    }
}