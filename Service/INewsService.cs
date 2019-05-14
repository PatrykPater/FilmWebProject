using Model.Models;
using System.Collections.Generic;

namespace Service
{
    public interface INewsService
    {
        List<News> GetAllNews();
        News GetNewsById(int id);
        void Complete();
    }
}