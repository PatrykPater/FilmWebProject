using Microsoft.AspNet.Identity;
using Model.Models;
using Service;
using System.Collections.Generic;
using System.Web.Http;

namespace Web.Controllers.Api
{
    public class NotificationsController : ApiController
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IEnumerable<Notification> List()
        {
            var userId = User.Identity.GetUserId();
            return _notificationService.GetAllUserNotifications(userId);
        }
    }
}
