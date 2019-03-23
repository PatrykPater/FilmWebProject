using System.Collections.Generic;
using Model.Models;

namespace Service
{
    public interface INotificationService
    {
        List<Notification> GetAllUserNotifications(string userId);
    }
}