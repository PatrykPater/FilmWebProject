using Model.Models;
using System.Collections.Generic;

namespace Service
{
    public interface INotificationService
    {
        List<Notification> GetAllUserNotifications(string userId);
        Notification GetNotificationById(int id);
        void AcceptFriendRequest(Notification notification);
        void Complete();
    }
}