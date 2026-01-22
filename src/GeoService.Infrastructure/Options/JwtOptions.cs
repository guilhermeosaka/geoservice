namespace GeoService.Infrastructure.Options;

public class JwtOptions
{
    public required string Key { get; init; }
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
    public required TimeSpan ExpiresIn { get; init; }
}