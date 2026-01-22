using GeoService.Domain.Interfaces;
using GeoService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace GeoService.Infrastructure.Persistence.Repositories;

public class CountryRepository(GeoDbContext dbContext) : ICountryRepository
{
    public async Task AddAsync(Country country) => await dbContext.AddAsync(country);

    public async Task<Country?> FindAsync(string id) =>
        await dbContext.Countries.Include(c => c.Cities).FirstOrDefaultAsync(c => c.Id == id && c.IsActive);

    public Task<bool> ExistsByIdAsync(string id) => dbContext.Countries.AnyAsync(c => c.Id == id);
}