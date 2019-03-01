namespace FilmWebProject.Core.Models
{
    public class Rating
    {
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }

        public Score Score { get; set; }
        public int ScoreId { get; set; }

        public int Value { get; set; }
    }
}