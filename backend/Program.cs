using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using Bogus;

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
    if (await db.Categories.AnyAsync() || await db.Movies.AnyAsync())
        return Results.BadRequest("Database already seeded.");

    // Generate random categories
    var categoryFaker = new Faker<Category>()
        .RuleFor(c => c.Name, f => f.Commerce.Categories(1)[0]);
    var categories = categoryFaker.Generate(5);
    db.Categories.AddRange(categories);
    await db.SaveChangesAsync();

    // Generate random movies and assign to categories
    var movieFaker = new Faker<Movie>()
        .RuleFor(m => m.Title, f => f.Lorem.Sentence(3, 2))
        .RuleFor(m => m.Description, f => f.Lorem.Paragraph())
        .RuleFor(m => m.CategoryId, f => f.PickRandom(categories).Id);
    var movies = movieFaker.Generate(20);
    db.Movies.AddRange(movies);
    await db.SaveChangesAsync();

    return Results.Ok("Database seeded with random data.");
});

// Get movies endpoint
app.MapGet("/movies", async (MovieContext db) =>
{
    // var categories = await db.Categories.Include(c => c.Movies).ToListAsync();
    // return Results.Json(categories, jsonOptions);
    var movies = await db.Movies.Include(m => m.Category).ToListAsync();
    return Results.Json(movies, jsonOptions);
});

app.Run();
