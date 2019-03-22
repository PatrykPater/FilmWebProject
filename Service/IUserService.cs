using Model.Models;
using System.Collections.Generic;

namespace Service
{
    public interface IUserService
    {
        List<ApplicationUser> GetAllUsers();
        List<ApplicationUser> GetUsersByQuery(List<ApplicationUser> allUsers, string query);
        ApplicationUser GetUserById(string id);
        void SendFriendRequest(ApplicationUser recipient, ApplicationUser sender);
        void Complete();
    }
}