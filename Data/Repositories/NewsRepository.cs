using Data.Infrastructure;
using Model.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Repositories
{
    public class NewsRepository : RepositoryBase<News>, INewsRepository
    {
        private readonly ApplicationDbContext _context;
        public NewsRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override List<News> GetAll()
        {
            return _context.News
                .Include(n => n.Author)
                .Include(n => n.Tags)
                .ToList();
        }

        public override News GetById(int id)
        {
            return _context.News
                .Include(n => n.Author)
                .Include(n => n.Tags)
                .Single(n => n.Id == id);
        }
    }
}
