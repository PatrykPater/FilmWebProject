using Model.Models;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IUserRepository
    {
        ApplicationUser GetUserById(string id);
        List<ApplicationUser> GetAllUsers();
    }
}