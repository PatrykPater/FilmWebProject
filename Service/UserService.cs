using Data.Infrastructure;
using Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<ApplicationUser> GetAllUsers()
        {
            return _unitOfWork.Users.GetAllUsers();
        }

        public List<ApplicationUser> GetUsersByQuery(List<ApplicationUser> allUsers, string query)
        {
            var lowerCaseQuery = query.ToLower();
            return allUsers.Where(u => u.FirstName.ToLower().Contains(lowerCaseQuery) || u.LastName.ToLower().Contains(lowerCaseQuery)).ToList();
        }

        public ApplicationUser GetUserById(string id)
        {
            return _unitOfWork.Users.GetUserById(id);
        }

        public void Complete()
        {
            _unitOfWork.Complete();
        }

        public void SendFriendRequest(ApplicationUser recipient, ApplicationUser sender)
        {
            var newNotification = new Notification() { Recipient = recipient, Sender = sender, NotificationType = NotificationType.FriendRequest };

            _unitOfWork.Notifications.Add(newNotification);
        }
    }
}
