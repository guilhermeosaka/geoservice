using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using GeoService.Application.Dtos;
using GeoService.Infrastructure.Persistence;
using MapService.Api.Dtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GeoService.Api.IntegrationTests.Controllers;

public class CountriesControllerTests(WebAppFactory factory) : IClassFixture<WebAppFactory>
{
    private readonly HttpClient _client = factory.CreateClient();

    #region Create 
    
    [Fact]
    public async Task Create_Success()
    {
        // Arrange
        await ResetDbAsync();
        
        var request = new CreateCountryRequest("BR", "Brazil", "South America", [
            new CityDto("Sao Paulo", 10000000),
            new CityDto("Rio de Janeiro", 5000000),
        ]);
    
        // Act
        var response = await _client.PostAsJsonAsync("/api/countries", request);
    
        // Assert
        response.EnsureSuccessStatusCode();
    
        await WithDbContextAsync(async dbContext =>
        {
            var countryDb = await dbContext.Countries.Include(c => c.Cities)
                .FirstOrDefaultAsync(c => c.Id == request.Acronym);
    
            countryDb.Should().NotBeNull();
            countryDb.Name.Should().Be(request.Name);
            countryDb.Continent.Should().Be(request.Continent);
            countryDb.Cities.Should().BeEquivalentTo(request.Cities);
        });
    }
    
    [Fact]
    public async Task Create_Fail()
    {
        // Arrange
        await ResetDbAsync();
        
        var request = new CreateCountryRequest("BR", "Brazil", "South America", [
            new CityDto("Sao Paulo", 10000000),
            new CityDto("Rio de Janeiro", 5000000),
        ]);
    
        // Act
        await _client.PostAsJsonAsync("/api/countries", request);
        var response = await _client.PostAsJsonAsync("/api/countries", request);
    
        // Assert
        response.StatusCode.Should().Be(HttpStatusCode.Conflict);
    
        await WithDbContextAsync(async dbContext =>
        {
            var countryDb = await dbContext.Countries.Include(c => c.Cities)
                .FirstOrDefaultAsync(c => c.Id == request.Acronym);
    
            countryDb.Should().NotBeNull();
            countryDb.Name.Should().Be(request.Name);
            countryDb.Continent.Should().Be(request.Continent);
            countryDb.Cities.Should().BeEquivalentTo(request.Cities);
        });
    }
    
    #endregion Create

    private async Task WithDbContextAsync(Func<GeoDbContext, Task> action)
    {
        using var scope = factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<GeoDbContext>();
        await action(db);
    }
    
    private async Task ResetDbAsync()
    {
        using var scope = factory.Services.CreateScope();
        var db = scope.ServiceProvider.GetRequiredService<GeoDbContext>();

        await db.Database.EnsureDeletedAsync();
        await db.Database.EnsureCreatedAsync();
    }
}