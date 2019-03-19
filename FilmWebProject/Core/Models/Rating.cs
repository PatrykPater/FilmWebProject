namespace FilmWebProject.Core.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int Value { get; set; }

        public ApplicationUser User { get; set; }
        public Film Film { get; set; }
    }
}