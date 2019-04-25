using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model.Models;

namespace Data.Helpers
{
    public class UserManagerHelper : IUserManagerHelper
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public UserManagerHelper(ApplicationDbContext context)
        {
            _context = context;
            _userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            _roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
        }

        public bool PromoteToMod(string userId)
        {

            var user = _userManager.FindById(userId);
            var userRoles = _userManager.GetRoles(userId);
            var moderatorRole = _roleManager.FindByName("Moderator");

            if (userRoles.Contains(moderatorRole.Name))
                return false;

            _userManager.AddToRole(user.Id, moderatorRole.Name);
            return true;

        }

        public bool IsModded(string userId)
        {
            var role = _roleManager.FindByName("Moderator");
            var userRoles = _userManager.GetRoles(userId);

            return userRoles.Contains(role.Name);
        }
    }
}
