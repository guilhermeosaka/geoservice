using GeoService.Application.Interfaces;

namespace GeoService.Infrastructure.Persistence;

public class UnitOfWork(GeoDbContext dbContext) : IUnitOfWork
{
    public async Task SaveChangesAsync(CancellationToken ct = default) => await dbContext.SaveChangesAsync(ct);
}