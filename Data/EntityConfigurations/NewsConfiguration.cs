using Model.Models;
using System.Data.Entity.ModelConfiguration;

namespace Data.EntityConfigurations
{
    public class NewsConfiguration : EntityTypeConfiguration<News>
    {
        public NewsConfiguration()
        {
            HasKey(n => n.Id);

            HasMany(n => n.Tags)
                .WithMany(t => t.News)
                .Map(nt =>
                {
                    nt.MapLeftKey("NewsRefId");
                    nt.MapRightKey("TypeRefId");
                    nt.ToTable("NewsAndNewsTags");
                });

            Property(n => n.Title).IsRequired();
            Property(n => n.DateOfPublication).IsRequired();

            HasRequired(n => n.Author)
                .WithMany(a => a.News);
        }
    }
}
