using AutoMapper;
using Model.Models;
using Service;
using Service.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class FilmsController : Controller
    {
        private readonly IFilmService _filmService;

        public FilmsController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            var genresFromDb = _filmService.GetAllGenres();
            var genresViewModel = Mapper.Map<List<Genre>, List<GenreViewModel>>(genresFromDb);
            var viewmodel = new FilmFormViewModel { Genres = genresViewModel };

            return View("FilmForm", viewmodel);
        }

        //TEST !!!
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FilmFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var genresFromDb = _filmService.GetAllGenres();
                var genresViewModel = Mapper.Map<List<Genre>, List<GenreViewModel>>(genresFromDb);

                viewModel.Genres = genresViewModel;

                return View("FilmForm", viewModel);
            }

            var newFilm = Mapper.Map<Film>(viewModel);
            var genreDto = Mapper.Map<List<GenreViewModel>, List<GenreDto>>(viewModel.Genres);
            var listOfSelectedGenres = _filmService.GetSelectedGenres(genreDto);
            newFilm.Genres = listOfSelectedGenres;

            _filmService.AddNewFilm(newFilm);
            _filmService.Complete();

            return RedirectToAction("Details", "Films", new { id = newFilm.Id });
        }

        //TEST !!!
        [HttpGet]
        public ActionResult List(FilmListParametersViewModel filmListParametersViewModel)
        {
            var storedFilmSearchResults = TempData["FilmSearchResults"] as FilmListParametersViewModel;

            var filmListParametersDto = Mapper.Map<FilmListParametersDto>(storedFilmSearchResults ?? filmListParametersViewModel);
            var films = _filmService.GetFilms(filmListParametersDto);

            var genresDto = Mapper.Map<List<Genre>, List<GenreDto>>(_filmService.GetAllGenres());

            var filmViewModel = new FilmListViewModel
            {
                ListOfFilms = films,
                //Genres = Mapper.Map<List<Genre>, List<GenreViewModel>>(_filmService.GetAllGenres()),
                Genres = Mapper.Map<List<Genre>, List<GenreViewModel>>(_filmService.GetAllGenres()), // Make it so that the app remembers the checked parameters 
                FilmListParameters =
                {
                    MaxPageNumber = _filmService.GetMaxPageNumber(filmListParametersViewModel.PageSize),
                    CurrentPage = filmListParametersViewModel.CurrentPage
                }
            };

            return View(filmViewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            if (id <= 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var film = _filmService.GetFilmById(id);

            if (film == null)
                return HttpNotFound();

            return View(film);
        }

        //TEST !!!
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int id)
        {
            if (id <= 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            var film = _filmService.GetFilmById(id);

            if (film == null)
                return HttpNotFound();

            var genresDto = Mapper.Map<List<Genre>, List<GenreDto>>(_filmService.GetAllGenres());
            var genresDtoWithSelected = _filmService.GetAllAndSelectedGenres(film.Genres, genresDto);

            var filmFormViewModel = Mapper.Map<FilmFormViewModel>(film);
            filmFormViewModel.Genres = Mapper.Map<List<GenreDto>, List<GenreViewModel>>(genresDtoWithSelected);

            return View("FilmForm", filmFormViewModel);
        }

        //TEST !!!
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Update(FilmFormViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                var genresFromDb = _filmService.GetAllGenres();
                var genresViewModel = Mapper.Map<List<Genre>, List<GenreViewModel>>(genresFromDb);

                viewModel.Genres = genresViewModel;

                return View("FilmForm", viewModel);
            }

            var filmDb = _filmService.GetFilmById(viewModel.Id);
            if (filmDb == null)
                return HttpNotFound();

            filmDb.Genres.Clear();

            var genreDto = Mapper.Map<List<GenreViewModel>, List<GenreDto>>(viewModel.Genres);
            var genres = _filmService.GetSelectedGenres(genreDto);

            var filmUpdate = Mapper.Map<Film>(viewModel);
            filmUpdate.Genres = genres;

            filmDb = filmUpdate;
            _filmService.Complete();

            return RedirectToAction("Details", new { id = filmDb.Id });
        }

        [HttpPost]
        public ActionResult Search(FilmListParametersViewModel filmListParameters)
        {
            filmListParameters.Genres = filmListParameters.Genres.Where(g => g.IsChecked).ToList();

            TempData["FilmSearchResults"] = filmListParameters;

            return RedirectToAction("List", "Films");
        }
    }
}