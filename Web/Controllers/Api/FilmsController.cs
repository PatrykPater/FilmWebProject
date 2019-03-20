using Data;
using Data.Infrastructure;
using Microsoft.AspNet.Identity;
using Model.Models;
using System.Linq;
using System.Web.Http;
using Web.Dtos;

namespace Web.Controllers.Api
{
    [Authorize]
    public class FilmsController : ApiController
    {
        //Implementing IUnit of Work and dependency injection breaks the api, find out why and fix it.

        private readonly ApplicationDbContext _context;
        private readonly UnitOfWork _unitOfWork;

        public FilmsController()
        {
            _context = new ApplicationDbContext();
            _unitOfWork = new UnitOfWork(_context);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Film id is invalid");

            var film = _unitOfWork.Films.GetOneFilm(id);

            if (film == null)
                return NotFound();

            _unitOfWork.Films.Remove(film);
            _unitOfWork.Complete();

            return Ok(); // Return 204 NoContent in the future
        }

        [HttpPost]
        public IHttpActionResult Rate(RatingDto ratingDto)
        {
            var film = _unitOfWork.Films.GetOneFilm(ratingDto.FilmId);
            var userId = User.Identity.GetUserId();

            var user = _context.Users.Single(u => u.Id == userId);

            var rating = film.Ratings.SingleOrDefault(r => r.Film.Id == ratingDto.FilmId && r.User.Id == userId);

            if (rating == null)
            {
                var newRating = new Rating { Film = film, User = user, Value = ratingDto.Value };
                film.Ratings.Add(newRating);

                _unitOfWork.Complete();
                return Ok();
            }

            rating.Value = ratingDto.Value;

            _unitOfWork.Complete();
            return Ok();
        }
    }
}