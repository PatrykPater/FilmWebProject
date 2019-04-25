using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Model.Models;

namespace Data.Helpers
{
    public class UserManagerHelper : IUserManagerHelper
    {
        private readonly ApplicationDbContext _context;

        public UserManagerHelper(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool PromoteToMod(string userId)
        {
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));

            var user = userManager.FindById(userId);
            var userRoles = userManager.GetRoles(userId);
            var moderatorRole = roleManager.FindByName("Moderator");

            if (userRoles.Contains(moderatorRole.Name))
                return false;

            userManager.AddToRole(user.Id, moderatorRole.Name);
            return true;

        }
    }
}
