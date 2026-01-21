using GeoService.Application.Dtos;

namespace MapService.Api.Dtos;

public record UpdateCountryRequest(IReadOnlyCollection<CityDto> Cities);