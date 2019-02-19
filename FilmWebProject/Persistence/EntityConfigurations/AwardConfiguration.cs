using FilmWebProject.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace FilmWebProject.Persistence.EntityConfigurations
{
    public class AwardConfiguration : EntityTypeConfiguration<Award>
    {
        public AwardConfiguration()
        {
            Property(a => a.Category)
                .HasMaxLength(100)
                .IsRequired();


            Property(a => a.Name)
                .HasMaxLength(50)
                .IsRequired();


            Property(a => a.Year)
                .IsRequired();
        }
    }
}