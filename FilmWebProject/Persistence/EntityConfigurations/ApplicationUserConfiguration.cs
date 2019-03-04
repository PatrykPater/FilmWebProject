using FilmWebProject.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace FilmWebProject.Persistence.EntityConfigurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            //fix duplicate column User_Id

            HasMany(u => u.Rating)
            .WithRequired(r => r.User);
        }
    }
}