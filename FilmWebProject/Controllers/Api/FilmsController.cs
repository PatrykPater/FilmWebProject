using AutoMapper;
using Library.API.Entities;
using Library.API.Helpers;
using Library.API.Models;
using Library.API.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Web.Http;
using FilmWebProject.Persistence;
using Microsoft.Extensions.Logging;

namespace FilmWebProject.Controllers.Api
{
    [Authorize]
    public class FilmsController : ApiController
    {
        private ApplicationDbContext _context;

        public FilmsController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult Delete(int id)
        {
            return NoContent();
        }
    }
}
