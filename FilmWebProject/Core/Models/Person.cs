using System;
using System.Collections.Generic;

namespace FilmWebProject.Core.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public int Height { get; set; }
        public byte[] ProfilePhoto { get; set; }
        public string Biography { get; set; }
        public double Score { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}