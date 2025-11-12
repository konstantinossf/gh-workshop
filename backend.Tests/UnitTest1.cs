using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using backend.Data;
using backend.Models;
using NUnit.Framework;

namespace backend.Tests
{
    public class MovieApiTests
    {
    private WebApplicationFactory<Program> _factory;
    private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            _factory = new WebApplicationFactory<Program>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        // Replace MovieContext with InMemory for isolation
                        var descriptor = services.SingleOrDefault(
                            d => d.ServiceType == typeof(DbContextOptions<MovieContext>));
                        if (descriptor != null)
                            services.Remove(descriptor);
                        services.AddDbContext<MovieContext>(options =>
                            options.UseInMemoryDatabase("TestDb"));
                    });
                });
            _client = _factory.CreateClient();
        }

        [TearDown]
        public void TearDown()
        {
            _client?.Dispose();
            _factory?.Dispose();
        }

        [Test]
        public async Task SeedEndpoint_ShouldSeedDatabase()
        {
            var response = await _client.PostAsync("/seed", null);
            var content = await response.Content.ReadAsStringAsync();
            // Accept both success and 'already seeded' as valid outcomes
            if (!response.IsSuccessStatusCode)
            {
                Assert.That(content.Contains("already seeded"), Is.True, $"Unexpected error: {content}");
            }

            // Check seeded data
            using var scope = _factory.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<MovieContext>();
            Assert.That(await db.Categories.CountAsync(), Is.GreaterThan(0));
            Assert.That(await db.Movies.CountAsync(), Is.GreaterThan(0));
        }

        [Test]
        public async Task MoviesEndpoint_ShouldReturnMovies()
        {
            // Ensure seeded
            await _client.PostAsync("/seed", null);
            var response = await _client.GetAsync("/movies");
            var content = await response.Content.ReadAsStringAsync();
            Assert.That(response.IsSuccessStatusCode, Is.True, $"Movies endpoint failed: {content}");
            Assert.That(content.Contains("Title"), Is.True, "Response does not contain movie titles.");
        }
    }
}
