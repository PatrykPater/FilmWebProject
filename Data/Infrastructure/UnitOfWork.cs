﻿using Data.Helpers;
using Data.Repositories;

namespace Data.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public IFilmRepository Films { get; }
        public IGenreRepository Genres { get; }
        public IUserRepository Users { get; }
        public IRatingRepository Ratings { get; set; }
        public INotificationRepository Notifications { get; }
        public IAwardRepository Awards { get; }
        public IPersonRepository Persons { get; set; }
        public INewsRepository News { get; set; }
        public IUserManagerHelper ManagerHelper { get; set; }
        public IReviewRepository Reviews { get; set; }
        public ICountryRepository Countries { get; set; }

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Films = new FilmRepository(_context);
            Genres = new GenreRepository(_context);
            Users = new UserRepository(_context);
            Ratings = new RatingRepository(_context);
            Notifications = new NotificationRepository(_context);
            Awards = new AwardRepository(_context);
            Persons = new PersonRepository(_context);
            News = new NewsRepository(_context);
            ManagerHelper = new UserManagerHelper(_context);
            Reviews = new ReviewRepository(_context);
            Countries = new CountryRepository(_context);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}