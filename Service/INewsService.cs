using Model.Models;
using System.Collections.Generic;

namespace Service
{
    public interface INewsService
    {
        IEnumerable<News> GetAllNews();
        News GetNewsById(int id);
        void Complete();
    }
}