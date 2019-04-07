using Service;
using System.Web.Http;

namespace Web.Controllers.Api
{
    public class PersonsController : ApiController
    {
        private readonly IPersonService _personService;

        public PersonsController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet]
        public object Get()
        {
            return _personService.GetAllPersons();
        }
    }
}
