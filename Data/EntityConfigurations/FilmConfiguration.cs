using Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfigurations
{
    public class FilmConfiguration : EntityTypeConfiguration<Film>
    {
        public FilmConfiguration()
        {
            HasMany(f => f.Genres)
                .WithMany(g => g.Films)
                .Map(fg =>
                {
                    fg.MapLeftKey("FilmRefId");
                    fg.MapRightKey("GenreRefId");
                    fg.ToTable("FilmGenre");
                });

            Property(f => f.Title)
                .IsRequired()
                .HasMaxLength(50);
        }
    }
}