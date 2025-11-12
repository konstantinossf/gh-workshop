using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using Bogus;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add MovieContext with in-memory database
        builder.Services.AddDbContext<MovieContext>(options =>
            options.UseInMemoryDatabase("MovieDb"));

        builder.Services.AddOpenApi();

        var app = builder.Build();

        var jsonOptions = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.IgnoreCycles,
            WriteIndented = true
        };

        if (app.Environment.IsDevelopment())
        {
            app.MapOpenApi();
        }

        // Seed endpoint
        app.MapPost("/seed", async (MovieContext db) =>
        {
            // Remove all movies and categories
            db.Movies.RemoveRange(db.Movies);
            db.Categories.RemoveRange(db.Categories);
            await db.SaveChangesAsync();

            // Add a default category
            var defaultCategory = new Category { Name = "Imported" };
            db.Categories.Add(defaultCategory);
            await db.SaveChangesAsync();

            // MCP movie data
            var mcpMovies = new[] {
                new Movie { Title = "Inception", Description = "Director: Christopher Nolan", Year = 2010, CategoryId = defaultCategory.Id },
                new Movie { Title = "The Godfather", Description = "Director: Francis Ford Coppola", Year = 1972, CategoryId = defaultCategory.Id },
                new Movie { Title = "Pulp Fiction", Description = "Director: Quentin Tarantino", Year = 1994, CategoryId = defaultCategory.Id },
                new Movie { Title = "The Shawshank Redemption", Description = "Director: Frank Darabont", Year = 1994, CategoryId = defaultCategory.Id },
                new Movie { Title = "The Dark Knight", Description = "Director: Christopher Nolan", Year = 2008, CategoryId = defaultCategory.Id }
            };
            db.Movies.AddRange(mcpMovies);
            await db.SaveChangesAsync();

            return Results.Stream(async stream =>
            {
                await JsonSerializer.SerializeAsync(stream, "Database seeded with MCP movie data.");
            }, "application/json");
        });

        // Get movies endpoint
        app.MapGet("/movies", async (MovieContext db) =>
        {
            var movies = await db.Movies.Include(m => m.Category).ToListAsync();
            var json = JsonSerializer.Serialize(movies, jsonOptions);
            return Results.Content(json, "application/json");
        });

        app.Run();
    }
}
