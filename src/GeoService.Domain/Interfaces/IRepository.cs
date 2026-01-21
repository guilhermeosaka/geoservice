namespace GeoService.Domain.Interfaces;

public interface IRepository<TAggregate, in TId>
{
    public Task AddAsync(TAggregate item);
    public Task<TAggregate?> FindAsync(TId id);
}