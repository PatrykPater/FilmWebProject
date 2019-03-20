using Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfigurations
{
    public class GenreConfiguration : EntityTypeConfiguration<Genre>
    {
        public GenreConfiguration()
        {
            Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}