using GeoService.Domain.Interfaces;
using GeoService.Domain.Models;

namespace GeoService.Infrastructure.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    public User? GetUserByKey(string key) => 
        key == "drinkwater" ? new User("drinkwater@example.com") : null;
}