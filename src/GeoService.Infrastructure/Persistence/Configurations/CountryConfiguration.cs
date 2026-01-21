using GeoService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GeoService.Infrastructure.Persistence.Configurations;

public class CountryConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.ToTable("Countries");
        
        builder.HasKey(c => c.Id);

        builder.HasMany(c => c.Cities)
            .WithOne()
            .HasForeignKey(ci => ci.CountryId)
            .IsRequired();

        builder.Navigation(c => c.Cities)
            .HasField("_cities")
            .UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}