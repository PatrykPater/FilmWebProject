using Model.Models;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface INotificationRepository
    {
        void AddNewNotification(Notification notification);
        List<Notification> GetAllUserNotifications(string userId);
    }
}