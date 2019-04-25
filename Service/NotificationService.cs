using Data.Infrastructure;
using Model.Models;
using System.Collections.Generic;

namespace Service
{
    public class NotificationService : ServiceBase, INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Notification> GetAllUserNotifications(string userId)
        {
            return _unitOfWork.Notifications.GetAllUserNotifications(userId);
        }

        public Notification GetNotificationById(int id)
        {
            return _unitOfWork.Notifications.GetById(id);
        }

        public void AcceptFriendRequest(Notification notification)
        {
            var recipient = notification.Recipient;
            var sender = notification.Sender;

            notification.Recipient.Friends.Add(sender);
            notification.Sender.Friends.Add(recipient);
        }
    }
}
