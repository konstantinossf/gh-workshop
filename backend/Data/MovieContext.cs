using Microsoft.EntityFrameworkCore;
using backend.Models;

namespace backend.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieUser> MovieUsers { get; set; }
        public DbSet<Favorites> Favorites { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Category 1 - * Movie
            modelBuilder.Entity<Category>()
                .HasMany(c => c.Movies)
                .WithOne(m => m.Category)
                .HasForeignKey(m => m.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Movie * - * MovieUser (many-to-many)
            modelBuilder.Entity<MovieUser>()
                .HasMany(mu => mu.FavoriteMovies)
                .WithMany(m => m.WatchedByUsers)
                .UsingEntity<Favorites>(
                    j => j
                        .HasOne(f => f.Movie)
                        .WithMany()
                        .HasForeignKey(f => f.MovieId),
                    j => j
                        .HasOne(f => f.MovieUser)
                        .WithMany()
                        .HasForeignKey(f => f.MovieUserId),
                    j =>
                    {
                        j.HasKey(f => f.Id);
                    }
                );

            // Favorites: many-to-one with MovieUser
            modelBuilder.Entity<Favorites>()
                .HasOne(f => f.MovieUser)
                .WithMany(mu => mu.Favorites)
                .HasForeignKey(f => f.MovieUserId);

            // Favorites: many-to-one with Movie
            modelBuilder.Entity<Favorites>()
                .HasOne(f => f.Movie)
                .WithMany(m => m.Favorites)
                .HasForeignKey(f => f.MovieId);
        }
    }
}

/*
Checklist:
- [x] Create class structure
- [x] Implement navigation properties if needed
- [x] Add data annotations for validation
*/
