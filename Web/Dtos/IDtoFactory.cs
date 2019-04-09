using Model.Models;

namespace Web.Dtos
{
    public interface IDtoFactory
    {
        PersonDto CreatePersonDto(Person person);
        NewsDto CreateNewsDto(News news);
    }
}