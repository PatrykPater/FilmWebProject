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

            //film has no score, create one
            if (film.Score == null)
            {

            }

            var score = _context.Scores.Single(s => s.Id == film.Score.Id);
            var userId = User.Identity.GetUserId();

            var existingRating = score.Ratings.First(r => r.UserId == userId && r.ScoreId == score.Id);

            //score.Rate();

            // create new ratingDto
            if (existingRating == null)
            {


                var newRating = new Rating { ScoreId = score.Id, UserId = userId, Value = ratingDto.Value };
                score.Ratings.Add(newRating);
                score.Value = score.Ratings.Average(r => r.Value);
            }

            // or user is updating his ratingDto



            return Ok();
        }
    }
}
