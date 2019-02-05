using System;
using System.Collections.Generic;

namespace FilmWebProject.Core.Models
{
    public abstract class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public int Height { get; set; }
        public List<Reward> Rewards { get; set; }
        public List<byte[]> Photos { get; set; }
        public byte[] ProfilePhoto { get; set; }
        public string Biography { get; set; }
        public List<Film> Films { get; set; }
        public double Score { get; set; }
    }
}