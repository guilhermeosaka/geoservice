using GeoService.Application.Dtos;

namespace GeoService.Application.Countries.UpdateCountry;

public record UpdateCountryCommand(string Id, IReadOnlyCollection<CityDto> Cities);