namespace GeoService.Application.Dtos;

public record CountryDto(string Name, string Continent, IReadOnlyCollection<CityDto> Cities);