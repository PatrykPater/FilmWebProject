using FilmWebProject.Core.Dtos;
using FilmWebProject.Core.Models;
using FilmWebProject.Persistence;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace FilmWebProject.Controllers.Api
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
            var film = _unitOfWork.Films.GetOneFilm(ratingDto.Id);

            var userId = User.Identity.GetUserId();

            //film has no score, create one
            if (film.Score == null)
            {
                var newScore = new Score();
                film.Score = newScore;

                var newRating = new Rating { Value = ratingDto.Value, ScoreId = newScore.Id, UserId = userId };

                newScore.Ratings.Add(newRating);
            }

            var existingRating = film.Score.Ratings.First(r => r.UserId == userId && r.ScoreId == film.Score.Id);

            // create new ratingDto
            if (existingRating == null)
            {
                var newRating = new Rating { ScoreId = film.Score.Id, UserId = userId, Value = ratingDto.Value };
                film.Score.Ratings.Add(newRating);
            }
            else
            {
                // or user is updating his ratingDto
                existingRating.Value = ratingDto.Value;
            }

            _unitOfWork.Complete();

            return Ok();
        }
    }
}
