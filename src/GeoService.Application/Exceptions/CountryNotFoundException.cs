namespace GeoService.Application.Exceptions;

public class CountryNotFoundException(string countryId) : Exception($"Country with id '{countryId}' not found");