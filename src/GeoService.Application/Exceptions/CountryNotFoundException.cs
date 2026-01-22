namespace GeoService.Application.Exceptions;

public class CountryNotFoundException(string countryId)
    : HandledException("Country not found", $"Country with id '{countryId}' not found");