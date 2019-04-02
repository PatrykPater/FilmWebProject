using Microsoft.AspNet.Identity;
using Service;
using System.Web.Mvc;
using Web.ViewModels;

namespace Web.Controllers
{
    public class NotificationsController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }


        public ActionResult List()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _notificationService.GetAllUserNotifications(userId);

            return View(notifications);
        }
    }
}