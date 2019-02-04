using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FilmWebProject.Core.ViewModels
{
    public class CreateStaffFormViewModel
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Date Of Birth")]
        public DateTime? DateOfBirth { get; set; }

        [Display(Name = "Place Of Birth")]
        public string PlaceOfBirth { get; set; }
        public int Height { get; set; }

        public IEnumerable<RoleForCreateStaffFrom> Role = new List<RoleForCreateStaffFrom>()
        {
            new RoleForCreateStaffFrom()
            {
                RoleType = "Composer"
            },
            new RoleForCreateStaffFrom()
            {
                RoleType = "Creator"
            },
            new RoleForCreateStaffFrom()
            {
                RoleType = "Director"
            },
            new RoleForCreateStaffFrom()
            {
                RoleType = "Photographer"
            },
            new RoleForCreateStaffFrom()
            {
                RoleType = "Scriptwriter"
            }
        };
    }
}