using System;

namespace FilmWebProject.Core.ViewModels
{
    public class CreateStaffFormViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public int Height { get; set; }
    }
}