using Model.Models;
using System.Collections.Generic;
using System.Data.Entity;
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
            return _context.Notifications
                .Where(n => n.Recipient.Id == userId && n.IsRead == false)
                .Include(n => n.Recipient)
                .Include(n => n.Sender)
                .ToList();
        }

        public Notification GetNotificationById(int id)
        {
            return _context.Notifications
                .Include(n => n.Recipient)
                .Include(n => n.Sender)
                .Single(n => n.IsRead == false && n.Id == id);
        }

        public void Complete()
        {
            _context.SaveChanges();
        }
    }
}
