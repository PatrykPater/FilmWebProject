using Data.Infrastructure;
using Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class NewsService : ServiceBase, INewsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NewsService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        public List<News> GetAllNews()
        {
            return _unitOfWork.News.GetAll()
                .Where(n => n.IsNew || n.IsNew ==
                            false) // Change this to true only in the future. For now in order to have some news displayed on the main page this will always take old news as well.
                .OrderByDescending(n => n.DateOfPublication)
                .ToList();
        }

        public News GetNewsById(int id)
        {
            return _unitOfWork.News.GetById(id);
        }
    }
}
