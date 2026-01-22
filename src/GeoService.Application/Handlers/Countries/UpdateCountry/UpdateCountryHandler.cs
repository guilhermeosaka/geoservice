using GeoService.Application.Exceptions;
using GeoService.Application.Interfaces;
using GeoService.Domain.Interfaces;

namespace GeoService.Application.Handlers.Countries.UpdateCountry;

public class UpdateCountryHandler(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
    : IHandler<UpdateCountryCommand>
{
    public async Task Handle(UpdateCountryCommand request, CancellationToken ct)
    {
        var country = await countryRepository.FindAsync(request.Id);
        
        if (country == null)
            throw new CountryNotFoundException(request.Id);

        foreach (var city in request.Cities)
            country.AddCity(city.Name, city.Population);

        await unitOfWork.SaveChangesAsync(ct);
    }
}