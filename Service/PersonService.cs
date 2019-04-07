using Data.Infrastructure;
using Model.Models;
using System.Collections.Generic;

namespace Service
{
    public class PersonService : IPersonService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Person> GetAllPersons()
        {
            return _unitOfWork.Persons.GetAll();
        }
    }
}
