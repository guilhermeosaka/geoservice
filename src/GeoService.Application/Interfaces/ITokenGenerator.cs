namespace GeoService.Application.Interfaces;

public interface ITokenGenerator
{
    string Generate(string userId, string email);
}