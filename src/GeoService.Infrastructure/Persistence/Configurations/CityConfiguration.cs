using GeoService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoService.Infrastructure.Persistence.Configurations;

public class CityConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Cities");
        
        builder.HasKey(c => c.Id);
        builder.Property(c => c.Id).ValueGeneratedNever(); 
    }
}