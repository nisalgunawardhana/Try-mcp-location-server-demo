using System;
using LocationServer.Models;

namespace LocationServer.Services;

    public class LocationService
    {
        private readonly List<Location> _locations = new List<Location>();
        private readonly string _filePath = "/Users/nisalgunawardhana/LocationServer/Data/locations.json";
        public LocationService()
        {
            if (File.Exists(_filePath))
            {
                _locations = System.Text.Json.JsonSerializer.Deserialize<List<Location>>(File.ReadAllText(_filePath)) ?? new List<Location>();
            }
        }

        public IEnumerable<Location> GetAllLocations()
        {
            return _locations;
        }

        public Location? GetLocationById(int id)
        {
            return _locations.FirstOrDefault(l => l.Id == id);
        }
        public void AddLocation(Location location)
        {
            if (location == null) throw new ArgumentNullException(nameof(location));
            _locations.Add(location);
        }
        public void UpdateLocation(int id, Location updatedLocation)
        {
            if (updatedLocation == null) throw new ArgumentNullException(nameof(updatedLocation));
            var index = _locations.FindIndex(l => l.Id == id);
            if (index != -1)
            {
                _locations[index] = updatedLocation;
            }
        }
        public void DeleteLocation(int id)
        {
            var location = _locations.FirstOrDefault(l => l.Id == id);
            if (location != null)
            {
                _locations.Remove(location);
            }
        }
        public void SaveChanges()
        {
            File.WriteAllText(_filePath, System.Text.Json.JsonSerializer.Serialize(_locations));
        }

     

        


       
    }


