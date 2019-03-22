using Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfigurations
{
    public class NotificationConfiguration : EntityTypeConfiguration<Notification>
    {
        public NotificationConfiguration()
        {
            HasKey(n => n.Id);

            HasRequired(n => n.Recipient).WithMany(u => u.Notifications);
        }
    }
}
