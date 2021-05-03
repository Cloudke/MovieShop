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
        public DbSet<MovieCast> MovieCast { get; set; }
        public DbSet<Crew> Crew { get; set; }
        public DbSet<MovieCrew> MovieCrew { get; set; }
        public DbSet<Cast> Cast { get; set; }

        public DbSet<Trailer> Trailer { get; set; }

        public DbSet<Favorite> Favorite { get; set; }
        public DbSet<Review> Review { get; set; }
        public DbSet<Purchase> Purchase { get; set; }

        public DbSet<Role> Role { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<User> UserRole { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MovieCrew>()
                 .HasKey(m => new { m.MovieId, m.CrewId, m.Department,m.Job });
            modelBuilder.Entity<MovieCrew>()
                .HasOne(mc => mc.Movie).WithMany(mc => mc.MovieCrews).HasForeignKey(mc => mc.MovieId);
            modelBuilder.Entity<MovieCrew>()
                .HasOne(mc => mc.Crew).WithMany(mc => mc.MovieCrews).HasForeignKey(mc => mc.CrewId);


            modelBuilder.Entity<MovieCast>()
                 .HasKey(m => new { m.MovieId, m.CastId,m.Character });
            modelBuilder.Entity<MovieCast>()
                .HasOne(mc => mc.Movie).WithMany(mc => mc.MovieCasts).HasForeignKey(mc => mc.MovieId);
            modelBuilder.Entity<MovieCast>()
                .HasOne(mc => mc.Cast).WithMany(mc => mc.MovieCasts).HasForeignKey(mc => mc.CastId);

            modelBuilder.Entity<UserRole>()
                .HasKey(m => new { m.UserId, m.RoleId });
            modelBuilder.Entity<Review>()
                .HasKey(m => new { m.MovieId, m.UserId });

            modelBuilder.Entity<Movie>().Ignore(m => m.Rating);
            modelBuilder.Entity<Movie>().Property(m => m.CreatedDate).HasDefaultValueSql("getdate()");
            modelBuilder.Entity<Movie>().HasMany(m => m.Genres).WithMany(g => g.Movies)
                    .UsingEntity<Dictionary<string, object>>("MovieGenre",
                        m => m.HasOne<Genre>().WithMany().HasForeignKey("GenreId"),
                        g => g.HasOne<Movie>().WithMany().HasForeignKey("MovieId"));

        }

    }
}
