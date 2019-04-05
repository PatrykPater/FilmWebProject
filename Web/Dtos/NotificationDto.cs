namespace Web.Dtos
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public bool IsAccepted { get; set; }
        public bool IsRead { get; set; } = false;
    }
}