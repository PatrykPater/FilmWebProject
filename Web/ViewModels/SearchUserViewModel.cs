using Model.Models;
using System.Collections.Generic;

namespace Web.ViewModels
{
    public class SearchUserViewModel
    {
        public SearchUserViewModel()
        {
            Users = new List<ApplicationUser>();
        }
        public string Query { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
    }
}