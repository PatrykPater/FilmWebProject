using FilmWebProject.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace FilmWebProject.Persistence.EntityConfigurations
{
    public class ReviewConfiguration : EntityTypeConfiguration<Review>
    {
        public ReviewConfiguration()
        {
            HasRequired(r => r.Film)
                .WithMany(f => f.Reviews);


            HasRequired(r => r.Author)
                .WithMany(au => au.Reviews);


            Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(75);
        }
    }
}