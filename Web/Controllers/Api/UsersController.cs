using Microsoft.AspNet.Identity;
using Service;
using System.Web.Http;

namespace Web.Controllers.Api
{
    [Authorize]
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IHttpActionResult SendFriendRequest(string id)
        {
            var senderId = User.Identity.GetUserId();

            var sender = _userService.GetUserById(senderId);
            var recipient = _userService.GetUserById(id);

            if (sender.Friends.Contains(recipient))
                return BadRequest();

            if (sender.Id == id)
                return BadRequest();

            _userService.SendFriendRequest(recipient, sender);

            _userService.Complete();

            return Ok();
        }
    }
}
