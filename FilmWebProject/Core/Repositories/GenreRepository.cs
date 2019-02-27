using FilmWebProject.Core.Models;
using FilmWebProject.Persistence;
using System.Collections.Generic;
using System.Linq;

namespace FilmWebProject.Core.Repositories
{
    public class GenreRepository
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
    }
}