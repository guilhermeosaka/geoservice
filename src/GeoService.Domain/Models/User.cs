namespace GeoService.Domain.Models;

public class User(string email)
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Email { get; private set; } = email;
}