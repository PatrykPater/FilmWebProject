using Model.Models;

namespace Data.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext _context;

        public NotificationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void AddNewNotification(Notification notification)
        {
            _context.Notifications.Add(notification);
        }
    }
}
