using FilmWebProject.Core.Repositories;

namespace FilmWebProject.Core
{
    public interface IUnitOfWork
    {
        IFilmRepository Films { get; }
        IGenreRepository Genres { get; }
        void Complete();
    }
}