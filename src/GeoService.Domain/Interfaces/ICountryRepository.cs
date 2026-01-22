using GeoService.Domain.Models;

namespace GeoService.Domain.Interfaces;

public interface ICountryRepository : IRepository<Country, string>
{
    Task<bool> ExistsByIdAsync(string id);
}