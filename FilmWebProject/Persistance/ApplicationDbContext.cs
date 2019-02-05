using System.Data.Entity;
using FilmWebProject.Core.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace FilmWebProject.Persistance
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Composer> Composers { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Photographer> Photographers { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Reward> Rewards { get; set; }
        public DbSet<Scriptwriter> Scriptwriters { get; set; }
        public DbSet<Trailer> Trailers { get; set; }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}