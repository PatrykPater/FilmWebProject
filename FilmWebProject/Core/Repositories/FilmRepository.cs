using FilmWebProject.Core.Models;
using FilmWebProject.Persistence;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FilmWebProject.Core.Repositories
{
    public class FilmRepository
    {
        private readonly ApplicationDbContext _context;

        public FilmRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Film> GetAllFilms()
        {
            return _context.Films
                .Include(f => f.Genres)
                .ToList();
        }

        public Film GetOneFilm(int id)
        {
            return _context.Films
                .Include(f => f.Genres)
                .Single(f => f.Id == id);
        }
    }
}