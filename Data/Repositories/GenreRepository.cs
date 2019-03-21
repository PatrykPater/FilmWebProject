using Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repositories
{
    public class GenreRepository : IGenreRepository
    {
        private readonly ApplicationDbContext _context;

        public GenreRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Genre> GetAllGenres()
        {
            return _context.Genres.ToList();
        }

        public Genre GetGenreById(int id)
        {
            return _context.Genres.Single(g => g.Id == id);
        }
    }
}