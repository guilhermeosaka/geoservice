using GeoService.Application.Interfaces;
using GeoService.Domain.Interfaces;
using GeoService.Domain.Models;

namespace GeoService.Application.Countries.CreateCountry;

public class CreateCountryHandler(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
    : IHandler<CreateCountryCommand>
{
    public async Task Handle(CreateCountryCommand request, CancellationToken ct)
    {
        var country = new Country(request.Acronym, request.Name, request.Continent);
        
        foreach (var city in request.Cities)
            country.AddCity(city.Name, city.Population);

        await countryRepository.AddAsync(country);
        await unitOfWork.SaveChangesAsync(ct);
    }
}