using FluentAssertions;
using GeoService.Domain.Models;

namespace GeoService.Domain.Tests.Models;

public class CountryTests
{
    [Fact]
    public void AddCity_ShouldAddCityOnlyOnceToCountry()
    {
        // Arrange
        const string cityName = "Sao Paulo";
        const int cityPopulation = 10000000;
        
        var country = new Country("BR", "Brazil", "South America");
        
        // Act
        country.AddCity(cityName, cityPopulation);
        country.AddCity(cityName, cityPopulation);
        
        // Assert
        country.Cities.Should().HaveCount(1);
        country.Cities.Should().Contain(c => c.Name == cityName && c.Population == cityPopulation);
    }
    
    [Fact]
    public void Deactivate_ShouldDeactivateCountry()
    {
        // Arrange
        var country = new Country("BR", "Brazil", "South America");
        
        // Act
        country.Deactivate();
        
        // Assert
        country.IsActive.Should().BeFalse();
        country.DeactivatedAt.Should().NotBeNull();
    }
}