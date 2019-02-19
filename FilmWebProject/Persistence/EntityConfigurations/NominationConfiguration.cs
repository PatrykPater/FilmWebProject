using System.Data.Entity.ModelConfiguration;
using FilmWebProject.Core.Models;

namespace FilmWebProject.Persistence.EntityConfigurations
{
    public class NominationConfiguration : EntityTypeConfiguration<Nomination>
    {
        public NominationConfiguration()
        {
            HasKey(ar => new { ar.AwardId, ar.FilmId });
        }
    }
}