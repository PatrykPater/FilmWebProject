using AutoMapper;
using FilmWebProject.Core;
using FilmWebProject.Core.Models;
using FilmWebProject.Core.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace FilmWebProject.Controllers
{
    public class FilmsController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public FilmsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [Authorize]
        public ActionResult Create()
        {
            var genresFromDb = _unitOfWork.Genres.GetAllGenres();
            var genresViewModel = Mapper.Map<List<Genre>, List<GenreViewModel>>(genresFromDb);
            var viewmodel = new FilmFormViewModel { Genres = genresViewModel };

            return View("FilmForm", viewmodel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FilmFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var genresFromDb = _unitOfWork.Genres.GetAllGenres();
                var genresViewModel = Mapper.Map<List<Genre>, List<GenreViewModel>>(genresFromDb);

                viewModel.Genres = genresViewModel;

                return View("FilmForm", viewModel);
            }

            var newFilm = Mapper.Map<Film>(viewModel);
            newFilm.Genres = _unitOfWork.Genres.GetSelectedGenres(viewModel);

            _unitOfWork.Films.Add(newFilm);
            _unitOfWork.Complete();

            return RedirectToAction("Index", "Home");
        }

        public ActionResult List(string query = null)
        {
            var films = _unitOfWork.Films.GetAllFilms();

            if (!string.IsNullOrWhiteSpace(query))
            {
                films = films
                    .Where(g =>
                        g.Title.Contains(query)).ToList();
            }

            var filmViewModel = new FilmListViewModel { ListOfFilms = films };

            return View(filmViewModel);
        }


        public ActionResult Details(int id)
        {
            var film = _unitOfWork.Films.GetOneFilm(id);

            if (film == null)
                return HttpNotFound();

            return View(film);
        }

        [Authorize]
        public ActionResult Edit(int id)
        {
            if (id <= 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var film = _unitOfWork.Films.GetOneFilm(id);

            if (film == null)
                return HttpNotFound();

            //further refactoring required

            var allGenresFromDb = _unitOfWork.Genres.GetAllGenres();

            var genresViewModel = Mapper.Map<List<Genre>, List<GenreViewModel>>(allGenresFromDb);

            foreach (var genreForViewModel in genresViewModel)
                foreach (var currentFilmGenre in film.Genres)
                    if (currentFilmGenre.Id == genreForViewModel.Id)
                        genreForViewModel.IsChecked = true;

            var filmFormViewModel = Mapper.Map<FilmFormViewModel>(film);
            filmFormViewModel.Genres = genresViewModel;

            // further refactoring required

            return View("FilmForm", filmFormViewModel);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Update(FilmFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var genresFromDb = _unitOfWork.Genres.GetAllGenres();
                var genresViewModel = Mapper.Map<List<Genre>, List<GenreViewModel>>(genresFromDb);

                viewModel.Genres = genresViewModel;

                return View("FilmForm", viewModel);
            }

            var filmFromDb = _unitOfWork.Films.GetOneFilm(viewModel.Id);

            if (filmFromDb == null)
                return HttpNotFound();

            filmFromDb.Genres.Clear();

            var genres = _unitOfWork.Genres.GetSelectedGenres(viewModel);

            filmFromDb.Update(genres, viewModel);
            _unitOfWork.Complete();

            return RedirectToAction("Details", new { id = filmFromDb.Id });
        }

        [HttpPost]
        public ActionResult Search(FilmListViewModel viewModel)
        {
            return RedirectToAction("List", "Films", new { query = viewModel.Search });
        }
    }
}