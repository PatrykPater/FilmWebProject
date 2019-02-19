using FilmWebProject.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace FilmWebProject.Persistence.EntityConfigurations
{
    public class PersonConfiguration : EntityTypeConfiguration<Person>
    {
        public PersonConfiguration()
        {
            HasMany(p => p.Jobs)
            .WithMany(j => j.Persons)
            .Map(pj =>
            {
                pj.MapLeftKey("PersonRefId");
                pj.MapRightKey("JobRefId");
                pj.ToTable("PersonJob");
            });

            Property(p => p.FirstName)
            .IsRequired()
            .HasMaxLength(50);

            Property(p => p.LastName)
            .IsRequired()
            .HasMaxLength(50);

            Property(p => p.Score)
            .IsOptional();
        }
    }
}