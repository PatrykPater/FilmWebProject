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
            var film = _context.Films.Single(f => f.Id == id);

            _context.Films.Remove(film);
            _context.SaveChanges();

            return Ok();
        }
    }
}
