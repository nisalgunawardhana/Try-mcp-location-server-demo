using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.ComponentModel;
using LocationServer.Services;
using ModelContextProtocol.Server;

namespace LocationServer.Tools;

[McpServerToolType]

public static class LocationsTools
{

    private static readonly LocationService _locationService = new LocationService();



    //getall location
    
    [McpServerTool(Name = "GetAllLocations"), Description("Retrieves all locations from the server.")]

    public static void GetAllLocations()
    {
        var locations = _locationService.GetAllLocations();
        var returnLocations = JsonSerializer.Serialize(locations);

        Console.WriteLine(returnLocations);
    }

    // get location by id
    
    [McpServerTool(Name = "GetLocationById"), Description("Retrieves a location by its ID.")]

    public static void GetLocationById(int id)
    {
        var location = _locationService.GetLocationById(id);
        var returnLocation = JsonSerializer.Serialize(location);

        Console.WriteLine(returnLocation);
    }

    // add a new location
    
    [McpServerTool(Name = "AddLocation"), Description("Adds a new location to the server.")]

    public static void AddLocation(string name, string description, double latitude, double longitude)
    {
        var newLocation = new LocationServer.Models.Location
        {
            Id = new Random().Next(10000, 99999), // Demo: random ID
            Name = name,
            Description = description,
            Latitude = latitude,
            Longitude = longitude
        };
        _locationService.AddLocation(newLocation);
        _locationService.SaveChanges();

        Console.WriteLine(JsonSerializer.Serialize(newLocation));
    }
  
}


