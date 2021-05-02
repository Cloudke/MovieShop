using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationCore.Entities;

namespace Infrastructure.Data
{
    public class MovieShopDbContext : DbContext
    {
        public MovieShopDbContext(DbContextOptions<MovieShopDbContext> options) : base(options)
        {

        }
        public DbSet<Movie> Movie { get; set; }
        public DbSet<Genre> Genre { get; set; }
        public DbSet<MovieGenre> MovieGenre { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<MovieCrew> MovieCrew { get; set; }
        public DbSet<Cast> Cast { get; set; }
        public DbSet<MovieCast> MovieCast { get; set; }
        public DbSet<Trailer> Trailer { get; set; }

        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<Review> Review { get; set; }

        public DbSet<User> User { get; set; }
        public DbSet<User> UserRole { get; set; }
        public DbSet<Role> Role { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieGenre>()
                .HasKey(m => new { m.MovieId, m.GenreId });
            modelBuilder.Entity<MovieCrew>()
                 .HasKey(m => new { m.MovieId, m.CrewId});
            modelBuilder.Entity<MovieCast>()
                 .HasKey(m => new { m.MovieId, m.CastId });
            modelBuilder.Entity<UserRole>()
                .HasKey(m => new { m.UserId, m.RoleId });
            modelBuilder.Entity<Review>()
                .HasKey(m => new { m.MovieId, m.UserId });

        }

    }
}
