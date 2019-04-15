using Data.Infrastructure;
using Model.Models;
using System.Collections.Generic;
using System.Linq;

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
            return _unitOfWork.News.GetAll()
                .Where(n => n.IsNew)
                .OrderByDescending(n => n.DateOfPublication)
                .Take(6);
        }

        public News GetNewsById(int id)
        {
            return _unitOfWork.News.GetById(id);
        }
    }
}
