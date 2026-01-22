namespace GeoService.Application.Exceptions;

public class CountryAlreadyExistsException(string acronym)
    : HandledException("Country already exists", $"Country with acronym '{acronym}' already exists.");