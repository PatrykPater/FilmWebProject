using Model.Models;

namespace Data.Repositories
{
    public interface INotificationRepository
    {
        void AddNewNotification(Notification notification);
    }
}