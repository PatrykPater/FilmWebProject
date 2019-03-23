using Model.Models;
using System.Collections.Generic;
using System.Linq;

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

        public List<Notification> GetAllUserNotifications(string userId)
        {
            return _context.Notifications.Where(n => n.Recipient.Id == userId).ToList();
        }
    }
}
