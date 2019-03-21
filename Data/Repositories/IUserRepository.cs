using Model.Models;

namespace Data.Repositories
{
    public interface IUserRepository
    {
        ApplicationUser GetUserById(string id);
    }
}