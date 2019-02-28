using FilmWebProject.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace FilmWebProject.Persistence.EntityConfigurations
{
    public class ScoreConfiguration : EntityTypeConfiguration<Score>
    {
        public ScoreConfiguration()
        {
            HasMany(s => s.Users)
                .WithMany(u => u.Ratings)
                .Map(su =>
                {
                    su.MapLeftKey("ScoreRefId");
                    su.MapRightKey("UserRefId");
                    su.ToTable("ScoreUser");
                });

            HasRequired(s => s.Film)
                .WithRequiredPrincipal(f => f.Score);
        }
    }
}