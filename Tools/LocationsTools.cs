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
    
    /*
    Task 2: Create a method to get a location by its ID.
    - Define a public static method (e.g., GetLocationById) that takes an ID parameter.
    - Use _locationService.GetLocationById(id) to fetch the location.
    - Serialize the result and print it.

    Task 3: Create a method to add a new location.
    - Define a public static method (e.g., AddLocation) that takes the necessary parameters for a location.
    - Create a new Location object and pass it to _locationService.AddLocation(location).
    - Optionally, serialize and print the result or confirmation.
    */

}


