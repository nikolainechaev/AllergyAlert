using System;

namespace allergyAPI.Models;

public class GeocodingResult
{
	public required string CityName { get; set; }
	public double Latitude { get; set; }
	public double Longitude { get; set; }
	public required string Country { get; set; }
	public string? State { get; set; }
}
