using System.Collections.Generic;
using Model.Models;

namespace Web.ViewModels
{
    public interface IModelFactory
    {
        UserListViewModel Create();
        UserListViewModel Create(ApplicationUser user, List<ApplicationUser> users);
    }
}