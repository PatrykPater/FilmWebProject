using AutoMapper;
using FilmWebProject.Core.Models;
using FilmWebProject.Core.Repositories;
using FilmWebProject.Core.ViewModels;
using FilmWebProject.Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FilmWebProject.Controllers
{
    public class FilmsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly GenreRepository _genreRepository;
        private readonly FilmRepository _filmRepository;


        public FilmsController()
        {
            _context = new ApplicationDbContext();
            _genreRepository = new GenreRepository(_context);
            _filmRepository = new FilmRepository(_context);
        }

        [Authorize]
        public ActionResult Create()
        {
            var genres = _genreRepository.GetAllGenres();
            var viewmodel = new FilmFormViewModel { Genre = GenreViewModel.GetGenresForViewModel(genres) };

            return View("FilmForm", viewmodel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FilmFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var genresFromDb = _genreRepository.GetAllGenres();

                viewModel.Genre = GenreViewModel.GetGenresForViewModel(genresFromDb);

                return View("FilmForm", viewModel);
            }

            var selectedGenresFromViewModel = Genre.GetSelectedGenres(viewModel.Genre);

            var genres = new List<Genre>();
            foreach (var genre in selectedGenresFromViewModel)
                genres.Add(_context.Genres.Single(g => g.Id == genre.Id));

            var newFilm = Mapper.Map<Film>(viewModel);

            newFilm.Genres = genres;

            _context.Films.Add(newFilm);
            _context.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult List()
        {
            var films = _filmRepository.GetAllFilms();
            return View(films);
        }


        public ActionResult Details(int id)
        {
            var film = _filmRepository.GetOneFilm(id);

            if (film == null)
                return HttpNotFound();

            return View(film);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            if (id <= 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var film = _filmRepository.GetOneFilm(id);

            if (film == null)
                return HttpNotFound();

            var genresFromDb = _genreRepository.GetAllGenres();
            var genres = GenreViewModel.GetGenresForViewModel(genresFromDb);

            foreach (var genre in genres)
                foreach (var genreDb in film.Genres)
                    if (genreDb.Id == genre.Id)
                        genre.IsChecked = true;

            var filmCreateFormViewModel = Mapper.Map<FilmFormViewModel>(film);
            filmCreateFormViewModel.Genre = genres;

            return View("FilmForm", filmCreateFormViewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Update(FilmFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var genresFromDb = _genreRepository.GetAllGenres();
                viewModel.Genre = GenreViewModel.GetGenresForViewModel(genresFromDb);

                return View("FilmForm", viewModel);
            }

            var filmFromDb = _filmRepository.GetOneFilm(viewModel.Id);

            if (filmFromDb == null)
                return HttpNotFound();

            filmFromDb.Genres.Clear();

            var genres = new List<Genre>();
            foreach (var genreViewModel in viewModel.Genre)
                if (genreViewModel.IsChecked)
                    genres.Add(_context.Genres.Single(g => g.Id == genreViewModel.Id));

            filmFromDb.Update(genres, viewModel);
            _context.SaveChanges();

            return RedirectToAction("Details", new { id = filmFromDb.Id });
        }
    }
}