using Microsoft.AspNet.Identity;
using Service;
using System.Linq;
using System.Web.Http;
using Web.Dtos;

namespace Web.Controllers.Api
{
    [Authorize]
    public class FilmsController : ApiController
    {
        private readonly IFilmService _filmService;

        public FilmsController(IFilmService filmService)
        {
            _filmService = filmService;
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Film id is invalid");

            var film = _filmService.GetFilmById(id);

            if (film == null)
                return NotFound();

            _filmService.RemoveFilm(film);
            _filmService.Complete();

            return Ok(); // Return 204 NoContent in the future
        }

        [HttpPost]
        public IHttpActionResult Rate(RatingDto ratingDto)
        {
            var film = _filmService.GetFilmById(ratingDto.FilmId);
            var userId = User.Identity.GetUserId();
            var user = _filmService.GetUserById(userId);
            var rating = film.Ratings.SingleOrDefault(r => r.Film.Id == ratingDto.FilmId && r.User.Id == userId);

            if (rating == null)
                _filmService.AddNewRating(film, user, ratingDto.Value);
            else
                rating.Value = ratingDto.Value;

            _filmService.Complete();
            return Ok();
        }
    }
}