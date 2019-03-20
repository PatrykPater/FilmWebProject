using Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfigurations
{
    public class TrailerConfiguration : EntityTypeConfiguration<Trailer>
    {
        public TrailerConfiguration()
        {
            HasRequired(t => t.Film)
                .WithMany(f => f.Trailers);


            Property(t => t.TrailerLink)
                .IsRequired()
                .HasMaxLength(300);
        }
    }
}