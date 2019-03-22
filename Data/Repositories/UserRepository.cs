using Model.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public ApplicationUser GetUserById(string id)
        {
            return _context.Users.Single(u => u.Id == id);
        }

        public List<ApplicationUser> GetAllUsers()
        {
            return _context.Users
                .Include(u => u.Friends)
                .Include(u => u.Ratings)
                .ToList();
        }
    }
}
