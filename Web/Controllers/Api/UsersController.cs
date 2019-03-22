using Microsoft.AspNet.Identity;
using Service;
using System.Web.Http;

namespace Web.Controllers.Api
{
    public class UsersController : ApiController
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Authorize]
        public IHttpActionResult SendFriendRequest(string id)
        {
            var senderId = User.Identity.GetUserId();

            var sender = _userService.GetUserById(senderId);
            var recipient = _userService.GetUserById(id);

            _userService.SendFriendRequest(recipient, sender);

            _userService.Complete();

            return Ok();
        }
    }
}
