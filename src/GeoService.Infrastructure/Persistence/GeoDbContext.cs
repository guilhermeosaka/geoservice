using GeoService.Domain.Models;
using GeoService.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace GeoService.Infrastructure.Persistence;

public class GeoDbContext(DbContextOptions<GeoDbContext> options) : DbContext(options)
{
    public DbSet<Country> Countries { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CountryConfiguration());
        modelBuilder.ApplyConfiguration(new CityConfiguration());
    }
}