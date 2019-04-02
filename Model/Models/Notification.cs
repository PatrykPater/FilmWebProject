namespace Model.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public bool IsRead { get; set; } = false;

        public ApplicationUser Recipient { get; set; }
        public ApplicationUser Sender { get; set; }
        public NotificationType NotificationType { get; set; }
    }

    public enum NotificationType
    {
        FriendRequest,
        NewFriendRating
    }
}