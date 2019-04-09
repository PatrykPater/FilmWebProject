using Model.Models;
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

        public NewsDto CreateNewsDto(News news)
        {
            return new NewsDto()
            {
                Author = news.Author,
                Content = news.Content,
                DateOfPublication = news.DateOfPublication,
                Tags = news.Tags.Select(t => CreateNewsTagDto(t)),
                Title = news.Title
            };
        }

        public NewsTagsDto CreateNewsTagDto(NewsTags newsTags)
        {
            return new NewsTagsDto()
            {
                Name = newsTags.Name
            };
        }
    }
}