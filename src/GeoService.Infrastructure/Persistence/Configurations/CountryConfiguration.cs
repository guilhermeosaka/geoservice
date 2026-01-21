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

        builder.Ignore(c => c.Cities);        
        
        builder
            .HasMany<City>("_cities")
            .WithOne()
            .HasForeignKey(ci => ci.CountryId)
            .IsRequired();
        
        builder.Navigation("_cities").UsePropertyAccessMode(PropertyAccessMode.Field);
    }
}