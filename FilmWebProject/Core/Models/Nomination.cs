namespace FilmWebProject.Core.Models
{
    public class Nomination
    {
        public Film Film { get; set; }
        public int FilmId { get; set; }
        public Award Award { get; set; }
        public int AwardId { get; set; }
        public bool HasWon { get; set; }
    }
}