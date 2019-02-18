namespace FilmWebProject.Core.Models
{
    public class AwardsResult
    {
        public Film Film { get; set; }
        public Award Award { get; set; }
        public bool HasWon { get; set; }
    }
}