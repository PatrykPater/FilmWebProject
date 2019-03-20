using Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfigurations
{
    public class JobConfiguration : EntityTypeConfiguration<Job>
    {
        public JobConfiguration()
        {
            Property(j => j.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}