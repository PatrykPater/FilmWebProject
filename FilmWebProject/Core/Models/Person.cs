using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilmWebProject.Core.Models
{
    public class Person
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string PlaceOfBirth { get; set; }
        public int Height { get; set; }
        public byte[] ProfilePhoto { get; set; }
        public string Biography { get; set; }
        public double Score { get; set; }

        [ForeignKey("Jobs")]
        public List<int> JobId { get; set; }
        public List<Job> Jobs { get; set; }
    }
}