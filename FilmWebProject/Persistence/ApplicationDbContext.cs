using FilmWebProject.Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace FilmWebProject.Persistence
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Award> Awards { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Nomination> Nominations { get; set; }
        public DbSet<Trailer> Trailers { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Film>()
                .HasMany(f => f.Genres)
                .WithMany(g => g.Films)
                .Map(fg =>
                {
                    fg.MapLeftKey("FilmRefId");
                    fg.MapRightKey("GenreRefId");
                    fg.ToTable("FilmGenre");
                });

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Jobs)
                .WithMany(j => j.Persons)
                .Map(pj =>
                {
                    pj.MapLeftKey("PersonRefId");
                    pj.MapRightKey("JobRefId");
                    pj.ToTable("PersonJob");
                });

            modelBuilder.Entity<Review>()
                .HasRequired(r => r.Film)
                .WithMany(f => f.Reviews);

            modelBuilder.Entity<Review>()
                .HasRequired(r => r.Author)
                .WithMany(au => au.Reviews);

            modelBuilder.Entity<Nomination>()
                .HasKey(ar => new { ar.AwardId, ar.FilmId });

            modelBuilder.Entity<Trailer>()
                .HasRequired(t => t.Film)
                .WithMany(f => f.Trailers);
        }
    }
}