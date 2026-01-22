using GeoService.Domain.Models;

namespace GeoService.Domain.Interfaces;

public interface IUserRepository
{
    User? GetUserByKey(string key);
}