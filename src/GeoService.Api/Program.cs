using System.Text;
using GeoService.Application.Dtos;
using GeoService.Application.Handlers.Countries.CreateCountry;
using GeoService.Application.Handlers.Countries.DeleteCountry;
using GeoService.Application.Handlers.Countries.GetCountryById;
using GeoService.Application.Handlers.Countries.UpdateCountry;
using GeoService.Application.Handlers.Tokens.CreateToken;
using GeoService.Application.Interfaces;
using GeoService.Domain.Interfaces;
using GeoService.Infrastructure.Options;
using GeoService.Infrastructure.Persistence;
using GeoService.Infrastructure.Persistence.Repositories;
using GeoService.Infrastructure.Services;
using MapService.Api.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("Jwt"));

builder.Services
    .AddEndpointsApiExplorer()
    .AddSwaggerGen()
    .AddDbContext<GeoDbContext>(options =>
        options.UseSqlServer(
            builder.Configuration.GetConnectionString("GeoDb"),
            sqlOptions => { sqlOptions.EnableRetryOnFailure(); }))
    .AddScoped<ICountryRepository, CountryRepository>()
    .AddScoped<IUserRepository, UserRepository>()
    .AddScoped<IUnitOfWork, UnitOfWork>()
    .AddScoped<ITokenGenerator, JwtGenerator>()
    .AddTransient<IHandler<CreateCountryCommand>, CreateCountryHandler>()
    .AddTransient<IHandler<UpdateCountryCommand>, UpdateCountryHandler>()
    .AddTransient<IHandler<DeleteCountryCommand>, DeleteCountryHandler>()
    .AddTransient<IHandler<GetCountryByIdQuery, CountryDto?>, GetCountryByIdHandler>()
    .AddTransient<IHandler<CreateTokenCommand, CreateTokenResult>, CreateTokenHandler>()
    .AddAuthentication(options =>
    {
        options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    })
    .AddJwtBearer(options =>
    {
        var jwtOptions = builder.Configuration.GetSection("Jwt").Get<JwtOptions>()!;
        
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtOptions.Issuer,
            ValidAudience = jwtOptions.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Key))
        };
    });

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.UseMiddleware<ErrorHandlerMiddleware>();

app.Run();