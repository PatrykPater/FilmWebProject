using Data.Infrastructure;
using Model.Models;
using System.Collections.Generic;

namespace Service
{
    public class FilmService
    {
        private readonly IUnitOfWork _unitOfWork;

        public FilmService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Genre> GetGenres()
        {
            return _unitOfWork.Genres.GetAllGenres();
        }
    }
}
