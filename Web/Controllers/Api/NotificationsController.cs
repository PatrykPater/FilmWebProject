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

        [HttpGet]
        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _notificationService.GetAllUserNotifications(userId);
            return notifications.Select(Mapper.Map<Notification, NotificationDto>);
        }

        //User can accept the same friend request multiple times, as well as send one to the same user. Fix in the nearby future

        [HttpPost]
        public IHttpActionResult FriendRequestResponse([FromBody]NotificationDto notificationDto)
        {
            var notification = _notificationService.GetNotificationById(notificationDto.Id);

            if (notificationDto.IsAccepted)
                _notificationService.AcceptFriendRequest(notification);

            notification.IsRead = true;

            _notificationService.Complete();

            return Ok();
        }
    }
}
