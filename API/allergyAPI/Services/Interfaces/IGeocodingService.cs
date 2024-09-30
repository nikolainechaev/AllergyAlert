using allergyAPI.Models;
using System.Threading.Tasks;

public interface IGeocodingService
{
	Task<GeocodingResult?> GetGeocodingDataAsync(string city, string country);
}

