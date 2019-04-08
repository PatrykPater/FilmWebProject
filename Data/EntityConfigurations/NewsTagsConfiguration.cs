using Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfigurations
{
    public class NewsTagsConfiguration : EntityTypeConfiguration<NewsTags>
    {
        public NewsTagsConfiguration()
        {
            HasKey(t => t.Id);
            Property(t => t.Name).IsRequired();
        }
    }
}
