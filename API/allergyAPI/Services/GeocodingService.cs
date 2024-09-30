using System.Net.Http;
using allergyAPI.Models;
using allergyAPI.Services;
using Newtonsoft.Json;

namespace allergyAPI.Services
{
	public class GeocodingService : IGeocodingService
	{
		private readonly HttpClient _httpClient;

		public GeocodingService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<GeocodingResult?> GetGeocodingDataAsync(string city, string country)
		{
			try
			{
				var ApiKey = Environment.GetEnvironmentVariable("GEOCODING_ENV") ?? throw new InvalidOperationException("API key not set.");
				var response = await _httpClient.GetStringAsync($"https://api.api-ninjas.com/v1/geocoding?city={city}&country={country}&x-api-key={ApiKey}");
				var geocodingResponses = JsonConvert.DeserializeObject<List<GeocodingResult>>(response);

				return geocodingResponses?.FirstOrDefault();
			}
			catch (HttpRequestException e)
			{
				Console.WriteLine($"Request error: {e.Message}");
				return null;
			}
			catch (JsonException e)
			{
				Console.WriteLine($"JSON error: {e.Message}");
				return null;
			}
		}

		public Task<GeocodingResult?> GetGeocodingResult(string city, string country)
		{
			throw new NotImplementedException();
		}
	}
}
