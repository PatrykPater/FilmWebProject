using System.Collections.Generic;
using Model.Models;

namespace Service
{
    public interface IPersonService
    {
        List<Person> GetAllPersons();
    }
}