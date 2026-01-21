namespace GeoService.Domain.Models;

public class City(string name, int population)
{
    public Guid Id { get; private init; } = Guid.NewGuid();
    public string Name { get; private set; } = name;
    public int Population { get; init; } = population;
    public string? CountryId { get; init; }
}