using GeoService.Application.Dtos;
using GeoService.Application.Exceptions;
using GeoService.Application.Interfaces;
using GeoService.Domain.Interfaces;

namespace GeoService.Application.Handlers.Countries.GetCountryById;

public class GetCountryByIdHandler(ICountryRepository countryRepository) : IHandler<GetCountryByIdQuery, CountryDto?>
{
    public async Task<CountryDto?> Handle(GetCountryByIdQuery request, CancellationToken ct)
    {
        var country = await countryRepository.FindAsync(request.Id);
        
        if (country == null)
            throw new CountryNotFoundException(request.Id);
        
        return new CountryDto(
            country.Name, 
            country.Continent,
            country.Cities.Select(c => new CityDto(c.Name, c.Population)).ToArray());
    }
}