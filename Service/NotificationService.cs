using Data.Infrastructure;
using Model.Models;
using System.Collections.Generic;

namespace Service
{
    public class NotificationService : INotificationService
    {
        private readonly IUnitOfWork _unitOfWork;

        public NotificationService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Notification> GetAllUserNotifications(string userId)
        {
            return _unitOfWork.Notifications.GetAllUserNotifications(userId);
        }
    }
}
