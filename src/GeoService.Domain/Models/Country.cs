namespace GeoService.Domain.Models;
 
 public class Country(string id, string name, string continent)
 {
     public string Id { get; private set; } = id;
     public string Name { get; private set; } = name;
     public string Continent { get; private set; } = continent;
     public bool IsActive { get; private set; } = true;
     public DateTime? DeactivatedAt { get; private set; }
     
     private readonly List<City> _cities = [];
     public IReadOnlyCollection<City> Cities => _cities.AsReadOnly();

     public void AddCity(string name, int population)
     {
         if (_cities.Any(c => c.Name == name)) return;
         _cities.Add(new City(name, population));
     }

     public void Deactivate(DateTime? deactivatedAt = null)
     {
         IsActive = false;
         DeactivatedAt = deactivatedAt ?? DateTime.UtcNow;
     }
 }