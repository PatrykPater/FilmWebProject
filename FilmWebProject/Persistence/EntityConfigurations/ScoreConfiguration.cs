using FilmWebProject.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace FilmWebProject.Persistence.EntityConfigurations
{
    public class ScoreConfiguration : EntityTypeConfiguration<Score>
    {
        public ScoreConfiguration()
        {
            HasMany(s => s.Ratings)
                .WithRequired(r => r.Score);
        }
    }
}