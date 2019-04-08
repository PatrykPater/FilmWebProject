using Model.Models;
using System.Collections.Generic;

namespace Web.ViewModels
{
    public class ModelFactory : IModelFactory
    {
        public UserListViewModel Create()
        {
            return new UserListViewModel();
        }

        public UserListViewModel Create(ApplicationUser user, List<ApplicationUser> users)
        {
            return new UserListViewModel()
            {
                User = user,
                Users = users,
                IsSearched = true
            };
        }
    }
}