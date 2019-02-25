using FilmWebProject.Persistence;
using System.Linq;
using System.Web.Http;

namespace FilmWebProject.Controllers.Api
{
    [Authorize]
    public class FilmsController : ApiController
    {
        private readonly ApplicationDbContext _context;

        public FilmsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid film id");

            var film = _context.Films.Single(f => f.Id == id);

            if (film == null)
                return NotFound();

            _context.Films.Remove(film);
            _context.SaveChanges();

            return Ok();
        }
    }
}
