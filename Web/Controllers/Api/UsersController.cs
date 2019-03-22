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
        public IHttpActionResult Add(string id)
        {
            var userId = User.Identity.GetUserId();

            var user = _userService.GetUserById(userId);
            var friend = _userService.GetUserById(id);

            user.Friends.Add(friend);
            friend.Friends.Add(user);

            _userService.Complete();

            return Ok();
        }
    }
}
