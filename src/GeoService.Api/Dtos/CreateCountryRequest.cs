using GeoService.Application.Dtos;

namespace MapService.Api.Dtos;

public record CreateCountryRequest(string Acronym, string Name, string Continent, IReadOnlyCollection<CityDto> Cities);