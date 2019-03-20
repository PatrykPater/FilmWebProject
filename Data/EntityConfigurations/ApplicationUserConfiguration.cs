using Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfigurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            HasMany(u => u.Rating)
            .WithRequired(r => r.User);
        }
    }
}