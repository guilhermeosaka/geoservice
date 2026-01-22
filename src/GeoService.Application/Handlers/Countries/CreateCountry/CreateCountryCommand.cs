using GeoService.Application.Dtos;

namespace GeoService.Application.Handlers.Countries.CreateCountry;

public record CreateCountryCommand(string Acronym, string Name, string Continent, IReadOnlyCollection<CityDto> Cities);