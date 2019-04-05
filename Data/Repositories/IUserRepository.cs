using Data.Infrastructure;
using Model.Models;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetUserById(string id);
        List<ApplicationUser> GetAllUsers();
    }
}