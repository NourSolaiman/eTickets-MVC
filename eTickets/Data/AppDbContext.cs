using eTickets.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data
{   //We have changed DbContext with IdentityDbContext<IdentityUser>
    public class AppDbContext:IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActorId,
                am.MovieId

            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.ActorId);


            base.OnModelCreating(modelBuilder);
        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actors_Movies { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Producer> Producers { get; set; }

        public DbSet<Login> Logins { get; set; }
        // Defined the relationships between all the modules & Complited appDbContext-file
    }
}
