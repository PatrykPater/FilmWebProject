using FilmWebProject.Core.Dtos;
using FilmWebProject.Persistence;
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
        public IHttpActionResult Rate(RatingDto rate)
        {
            var film = _unitOfWork.Films.GetOneFilm(rate.Id);

            film.Score = (film.Score + rate.Rating) / 2;

            return Ok();
        }
    }
}
