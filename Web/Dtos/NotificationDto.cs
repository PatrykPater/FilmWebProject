namespace Web.Dtos
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public string Action { get; set; }
        public bool IsRead { get; set; } = false;
    }
}