using System;
using System.Collections.Generic;

namespace Model.Models
{
    public class Person
    {
        public Person()
        {
            Jobs = new List<Job>();
        }
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public int Height { get; set; }
        public byte[] ProfilePhoto { get; set; }
        public string Biography { get; set; }
        public double Score { get; set; }

        public ICollection<Job> Jobs { get; private set; }
    }
}