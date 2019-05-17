using Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfigurations
{
    public class CountryConfiguration : EntityTypeConfiguration<Country>
    {
        public CountryConfiguration()
        {
            HasKey(c => c.Id);

            HasMany(f => f.Films)
                .WithMany(g => g.Country)
                .Map(fg =>
                {
                    fg.MapLeftKey("FilmRefId");
                    fg.MapRightKey("CountryRefId");
                    fg.ToTable("FilmCountry");
                });

            Property(c => c.Name).HasMaxLength(50);
        }
    }
}
