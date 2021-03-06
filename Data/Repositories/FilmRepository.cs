﻿using Data.Infrastructure;
using Model.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Repositories
{
    public class FilmRepository : RepositoryBase<Film>, IFilmRepository
    {
        private readonly ApplicationDbContext _context;

        public FilmRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public override List<Film> GetAll()
        {
            return _context.Films
                    .Include(f => f.Genres)
                    .Include(f => f.Ratings)
                    .Include(f => f.Countries)
                    .ToList();
        }

        public override Film GetById(int id)
        {
            return _context.Films
                    .Include(f => f.Genres)
                    .Include(f => f.Ratings)
                    .Include(f => f.Countries)
                    .Single(f => f.Id == id);
        }

        public List<Film> GetFilmsWithPagination(int pageSize, int pageNumber)
        {
            return _context.Films
                .Include(f => f.Genres)
                .Include(f => f.Ratings)
                .Include(f => f.Countries)
                .OrderBy(f => f.Title)
                .Skip(pageSize * pageNumber)
                .Take(pageSize)
                .ToList();
        }

        public int GetAllFilmCount()
        {
            return _context.Films.Count();
        }

        public void Update(Film filmUpdate)
        {
            _context.Entry(filmUpdate).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}