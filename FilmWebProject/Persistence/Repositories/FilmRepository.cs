using FilmWebProject.Core.Models;
using FilmWebProject.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace FilmWebProject.Persistence.Repositories
{
    public class FilmRepository : IFilmRepository
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
                .Include(f => f.Score)
                .Single(f => f.Id == id);
        }

        public void Add(Film newFilm)
        {
            _context.Films.Add(newFilm);
        }

        public void Remove(Film film)
        {
            _context.Films.Remove(film);
        }
    }
}