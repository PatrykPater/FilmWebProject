using Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace Web.Dtos
{
    public class DtoFactory : IDtoFactory
    {
        public PersonDto CreatePersonDto(Person person)
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
                Jobs = person.Jobs.Select(j => CreateJobDto(j))
            };
        }

        public JobDto CreateJobDto(Job job)
        {
            return new JobDto()
            {
                Name = job.Name
            };
        }

        public List<NewsDto> CreateNewsDto(IEnumerable<News> news)
        {
            return new List<NewsDto>();
        }
    }
}