﻿using FilmWebProject.Core.ViewModels;
using FilmWebProject.Persistance;
using System.Web.Mvc;

namespace FilmWebProject.Controllers
{
    public class DirectorsController : Controller
    {
        private ApplicationDbContext _context;

        public DirectorsController()
        {
            _context = new ApplicationDbContext();
        }

        [Authorize]
        public ActionResult Create()
        {
            var viewModel = new CreatePersonFormViewModel();

            return View(viewModel);
        }
    }
}