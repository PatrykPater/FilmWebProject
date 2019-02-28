using FilmWebProject.Core;
using System.Web.Http;

namespace FilmWebProject.Controllers.Api
{
    [Authorize]
    public class FilmsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public FilmsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid film id");

            var film = _unitOfWork.Films.GetOneFilm(id);

            if (film == null)
                return NotFound();

            _unitOfWork.Films.Remove(film);
            _unitOfWork.Complete();

            return Ok();
        }
    }
}
