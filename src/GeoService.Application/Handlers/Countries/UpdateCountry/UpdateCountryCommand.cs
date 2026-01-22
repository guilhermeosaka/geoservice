using GeoService.Application.Dtos;

namespace GeoService.Application.Handlers.Countries.UpdateCountry;

public record UpdateCountryCommand(string Id, IReadOnlyCollection<CityDto> Cities);