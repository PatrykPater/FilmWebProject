using Model.Models;
using System.Collections.Generic;

namespace Service
{
    public interface IPersonService
    {
        List<Person> GetAllPersons();
        void Complete();
    }
}