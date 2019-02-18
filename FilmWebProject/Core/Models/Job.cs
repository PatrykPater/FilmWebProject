using System.Collections.Generic;

namespace FilmWebProject.Core.Models
{
    public class Job
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Person> Persons { get; set; }
    }
}