using Model.Models;
using System.Linq;

namespace Web.Dtos
{
    public class DtoFactory : IDtoFactory
    {
        public PersonDto Create(Person person)
        {
            return new PersonDto
            {
                FirstName = person.FirstName,
                LastName = person.LastName,
                Biography = person.Biography,
                DateOfBirth = person.DateOfBirth,
                Height = person.Height,
                PlaceOfBirth = person.PlaceOfBirth,
                ProfilePhoto = person.ProfilePhoto,
                Score = person.Score,
                Jobs = person.Jobs.Select(j => Create(j))
            };
        }

        public JobDto Create(Job job)
        {
            return new JobDto()
            {
                Name = job.Name
            };
        }
    }
}