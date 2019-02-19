namespace FilmWebProject.Core.Models
{
    public class Trailer
    {
        public int Id { get; set; }
        public string TrailerLink { get; set; }
        public Film Film { get; set; }
    }
}