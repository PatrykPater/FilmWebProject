using Model.Models;
using System.Linq;
using Web.Helpers;

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
                Jobs = person.Jobs.Select(CreateJobDto)
            };
        }

        public JobDto CreateJobDto(Job job)
        {
            return new JobDto
            {
                Name = job.Name
            };
        }

        public NewsDto CreateNewsDto(News news)
        {
            return new NewsDto
            {
                Id = news.Id,
                Author = CreateUserDto(news.Author),
                Content = news.Content,
                DateOfPublication = news.DateOfPublication,
                Tags = news.Tags.Select(CreateNewsTagDto),
                Title = news.Title,
                ShortDescription = news.ShortDescription
            };
        }

        public NewsTagsDto CreateNewsTagDto(NewsTags newsTags)
        {
            return new NewsTagsDto
            {
                Name = newsTags.Name
            };
        }

        public UserDto CreateUserDto(ApplicationUser user)
        {
            return new UserDto
            {
                UserName = DtoFactoryHelper.GetFullUserName(user.FirstName, user.LastName)
            };
        }
    }
}