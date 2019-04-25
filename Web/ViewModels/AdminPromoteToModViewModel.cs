namespace Web.ViewModels
{
    public class AdminPromoteToModViewModel
    {
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsPromoted { get; set; } = false;
    }
}