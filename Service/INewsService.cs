using Model.Models;
using System.Collections.Generic;

namespace Service
{
    public interface INewsService
    {
        IEnumerable<News> GetAllNews();
    }
}