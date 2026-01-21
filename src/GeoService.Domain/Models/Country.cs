namespace GeoService.Domain.Models;

public class Country
{
    public required string Id { get; set; }
    public required string Name { get; set; }
    public required string Continent { get; set; }
    
    private readonly List<City> _cities = [];
    public IReadOnlyCollection<City> Cities => _cities.AsReadOnly();
    
    public void AddCity(City city) => _cities.Add(city);
}