using Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfigurations
{
    public class NominationConfiguration : EntityTypeConfiguration<Nomination>
    {
        public NominationConfiguration()
        {
            HasKey(ar => new { ar.AwardId, ar.FilmId });
        }
    }
}