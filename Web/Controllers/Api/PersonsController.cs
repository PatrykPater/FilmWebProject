﻿using Service;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Web.Dtos;

namespace Web.Controllers.Api
{
    public class PersonsController : ApiController
    {
        private readonly IPersonService _personService;
        private readonly IDtoFactory _dtoFactory;

        public PersonsController(IPersonService personService, IDtoFactory dtoFactory)
        {
            _personService = personService;
            _dtoFactory = dtoFactory;
        }

        [HttpGet]
        public IEnumerable<PersonDto> Get()
        {
            var persons = _personService.GetAllPersons()
                .OrderBy(p => p.LastName)
                .Select(p => _dtoFactory.CreatePersonDto(p));

            return persons;

        }
    }
}