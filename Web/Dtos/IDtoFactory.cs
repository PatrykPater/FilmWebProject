using Model.Models;

namespace Web.Dtos
{
    public interface IDtoFactory
    {
        JobDto Create(Job job);
        PersonDto Create(Person person);
    }
}