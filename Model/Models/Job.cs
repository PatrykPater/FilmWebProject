using System.Collections.Generic;

namespace Model.Models
{
    public class Job
    {
        public Job()
        {
            Persons = new List<Person>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Person> Persons { get; private set; }
    }
}