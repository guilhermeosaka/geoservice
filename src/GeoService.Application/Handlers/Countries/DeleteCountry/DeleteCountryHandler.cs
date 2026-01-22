using GeoService.Application.Exceptions;
using GeoService.Application.Interfaces;
using GeoService.Domain.Interfaces;

namespace GeoService.Application.Handlers.Countries.DeleteCountry;

public class DeleteCountryHandler(ICountryRepository countryRepository, IUnitOfWork unitOfWork)
    : IHandler<DeleteCountryCommand>
{
    public async Task Handle(DeleteCountryCommand request, CancellationToken ct)
    {
        var country = await countryRepository.FindAsync(request.Id);
        
        if (country == null)
            throw new CountryNotFoundException(request.Id);

        country.Deactivate();

        await unitOfWork.SaveChangesAsync(ct);
    }
}