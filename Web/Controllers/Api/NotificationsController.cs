using AutoMapper;
using Microsoft.AspNet.Identity;
using Model.Models;
using Service;
using System.Linq;
using System.Net;
using System.Web.Http;
using Web.Dtos;

namespace Web.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        private readonly INotificationService _notificationService;

        public NotificationsController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public IHttpActionResult GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _notificationService.GetAllUserNotifications(userId);
            return Ok(notifications.Select(Mapper.Map<Notification, NotificationDto>));
        }

        [HttpPost]
        public IHttpActionResult FriendRequestResponse(NotificationDto notificationDto)
        {
            if (!ModelState.IsValid)
                return StatusCode(HttpStatusCode.BadRequest);
            var notification = _notificationService.GetNotificationById(notificationDto.Id);

            if (notificationDto.IsAccepted)
                _notificationService.AcceptFriendRequest(notification);

            notification.IsRead = true;
            _notificationService.Complete();

            return Ok();
        }
    }
}
