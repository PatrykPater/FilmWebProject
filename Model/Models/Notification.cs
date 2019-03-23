using System;

namespace Model.Models
{
    public class Notification
    {
        public Guid Id { get; set; }
        public bool IsRead { get; set; } = false;

        public ApplicationUser Recipient { get; set; }
        public ApplicationUser Sender { get; set; }
    }
}