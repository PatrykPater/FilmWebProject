﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FilmWebProject.Core.ViewModels
{
    public class CreatePersonFormViewModel
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
    }
}