using Data.Infrastructure;
using Model.Models;
using System.Collections.Generic;

namespace Service
{
    public class NewsService : INewsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NewsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public IEnumerable<News> GetAllNews()
        {
            return _unitOfWork.News.GetAll();
        }
    }
}
