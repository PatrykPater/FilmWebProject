using FilmWebProject.Core.Repositories;

namespace FilmWebProject.Persistence
{
    public interface IUnitOfWork
    {
        IFilmRepository Films { get; }
        IGenreRepository Genres { get; }
        void Complete();
    }
}