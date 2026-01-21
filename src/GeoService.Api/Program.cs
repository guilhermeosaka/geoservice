using GeoService.Application.Countries.CreateCountry;
using GeoService.Application.Countries.DeleteCountry;
using GeoService.Application.Countries.GetCountryById;
using GeoService.Application.Countries.UpdateCountry;
using GeoService.Application.Dtos;
using GeoService.Application.Interfaces;
using GeoService.Domain.Interfaces;
using GeoService.Infrastructure.Persistence;
using GeoService.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddDbContext<GeoDbContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("GeoDb"),
            sqlOptions => { sqlOptions.EnableRetryOnFailure(); }))
    .AddScoped<ICountryRepository, CountryRepository>()
    .AddScoped<IUnitOfWork, UnitOfWork>()
    .AddTransient<IHandler<CreateCountryCommand>, CreateCountryHandler>()
    .AddTransient<IHandler<UpdateCountryCommand>, UpdateCountryHandler>()
    .AddTransient<IHandler<DeleteCountryCommand>, DeleteCountryHandler>()
    .AddTransient<IHandler<GetCountryByIdQuery, CountryDto?>, GetCountryByIdHandler>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();