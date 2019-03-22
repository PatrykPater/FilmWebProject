using System;

namespace Model.Models
{
    public class Notification
    {
        public Guid Id { get; set; }

        public ApplicationUser Recipient { get; set; }
        public ApplicationUser Sender { get; set; }
    }
}