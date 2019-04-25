using Model.Models;
using System.Collections.Generic;

namespace Service
{
    public interface IUserService
    {
        List<ApplicationUser> GetAllUsers();
        List<ApplicationUser> GetUsersByQuery(string query);
        ApplicationUser GetUserById(string id);
        void SendFriendRequest(ApplicationUser recipient, ApplicationUser sender);
        ApplicationUser GetUserByEmail(string email);
        void Complete();
    }
}