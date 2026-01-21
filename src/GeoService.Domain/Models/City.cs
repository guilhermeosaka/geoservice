namespace GeoService.Domain.Models;

public class City
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public int Population { get; set; }
    public required string CountryId { get; set; }
}