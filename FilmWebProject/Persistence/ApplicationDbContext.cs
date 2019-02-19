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

            modelBuilder.Entity<Film>()
                .Property(f => f.Title)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Genre>()
                .Property(g => g.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Job>()
                .Property(j => j.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Jobs)
                .WithMany(j => j.Persons)
                .Map(pj =>
                {
                    pj.MapLeftKey("PersonRefId");
                    pj.MapRightKey("JobRefId");
                    pj.ToTable("PersonJob");
                });

            modelBuilder.Entity<Person>()
                .Property(p => p.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Person>()
                .Property(p => p.LastName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Person>()
                .Property(p => p.Score)
                .IsOptional();

            modelBuilder.Entity<Review>()
                .HasRequired(r => r.Film)
                .WithMany(f => f.Reviews);

            modelBuilder.Entity<Review>()
                .HasRequired(r => r.Author)
                .WithMany(au => au.Reviews);

            modelBuilder.Entity<Review>()
                .Property(r => r.Title)
                .IsRequired()
                .HasMaxLength(75);

            modelBuilder.Entity<Nomination>()
                .HasKey(ar => new { ar.AwardId, ar.FilmId });

            modelBuilder.Entity<Trailer>()
                .HasRequired(t => t.Film)
                .WithMany(f => f.Trailers);

            modelBuilder.Entity<Trailer>()
                .Property(t => t.TrailerLink)
                .IsRequired()
                .HasMaxLength(300);

            modelBuilder.Entity<Award>()
                .Property(a => a.Category)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Award>()
                .Property(a => a.Name)
                .HasMaxLength(50)
                .IsRequired();

            modelBuilder.Entity<Award>()
                .Property(a => a.Year)
                .IsRequired();
        }
    }
}