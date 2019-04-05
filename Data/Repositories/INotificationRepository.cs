using Data.Infrastructure;
using Model.Models;
using System.Collections.Generic;

namespace Data.Repositories
{
    public interface INotificationRepository : IRepository<Notification>
    {
        //void AddNewNotification(Notification notification);
        List<Notification> GetAllUserNotifications(string userId);
        //Notification GetNotificationById(int id);
    }
}