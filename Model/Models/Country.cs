using System.Collections.Generic;

namespace Model.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<Film> Films { get; set; }
    }
}
