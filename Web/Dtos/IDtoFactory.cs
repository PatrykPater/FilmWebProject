using Model.Models;
using System.Collections.Generic;

namespace Web.Dtos
{
    public interface IDtoFactory
    {
        JobDto CreateJobDto(Job job);
        PersonDto CreatePersonDto(Person person);
        List<NewsDto> CreateNewsDto(IEnumerable<News> news);
    }
}