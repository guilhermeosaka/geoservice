using GeoService.Infrastructure.Persistence;
using Microsoft.Extensions.DependencyInjection;

namespace GeoService.Api.IntegrationTests.Extensions;

public static class ServiceCollectionExtensions
{
    extension(IServiceCollection services)
    {
        public void EnsureDbCreated()
        {
            var sp = services.BuildServiceProvider();
            using var scope = sp.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<GeoDbContext>();
            db.Database.EnsureCreated();
        }
    }
}