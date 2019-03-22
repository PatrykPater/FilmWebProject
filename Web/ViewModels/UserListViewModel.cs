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
    }
}