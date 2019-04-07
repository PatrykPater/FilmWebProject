using Model.Models;
using System.Collections.Generic;

namespace Web.ViewModels
{
    public class UserListViewModel
    {
        public UserListViewModel()
        {
            Users = new List<ApplicationUser>();
        }
        public string Query { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
        public bool IsSearched { get; set; } = false;
        public ApplicationUser User { get; set; }
    }
}