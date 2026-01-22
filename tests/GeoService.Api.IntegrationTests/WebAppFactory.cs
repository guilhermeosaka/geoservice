using GeoService.Api.IntegrationTests.Extensions;
using GeoService.Infrastructure.Persistence;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace GeoService.Api.IntegrationTests;

public class WebAppFactory : WebApplicationFactory<Program>
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.RemoveAll<DbContextOptions<GeoDbContext>>();
            services.RemoveAll<DbContextOptions>();
            services.RemoveAll<IDbContextOptionsConfiguration<GeoDbContext>>();
            services.RemoveAll<GeoDbContext>();
            
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();       
            
            services.AddDbContext<GeoDbContext>(options => options.UseSqlite(connection));

            services.EnsureDbCreated();
        });
    }
}