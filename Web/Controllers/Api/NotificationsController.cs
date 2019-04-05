using AutoMapper;
using Microsoft.AspNet.Identity;
using Model.Models;
using Service;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Web.Dtos;

namespace Web.Controllers.Api
{
    public class NotificationsController : ApiController
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _notificationService.GetAllUserNotifications(userId);
            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }

        [HttpPost]
        public IHttpActionResult FriendRequestResponse([FromBody]NotificationDto notificationDto)
        {

            return Ok();
        }
    }
}
