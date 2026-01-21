using GeoService.Domain.Models;

namespace GeoService.Domain.Interfaces;

public interface ICountryRepository : IRepository<Country, string>
{
    Task<IReadOnlyList<Country>> GetByFilterAsync(string continent, CancellationToken ct);
}