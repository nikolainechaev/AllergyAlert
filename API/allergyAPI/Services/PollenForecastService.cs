using allergyAPI.Services;
using Newtonsoft.Json;

public class PollenForecastService : IPollenForecastService
{
	private readonly HttpClient _httpClient;
	private readonly IGeocodingService _geocodingService;

	public PollenForecastService(HttpClient httpClient, IGeocodingService geocodingService)
	{
		_httpClient = httpClient;
		_geocodingService = geocodingService;
	}

	public async Task<PollenForecast?> GetForecastAsync(string city, string country, int days)
	{
		// Get geocoding data
		var geocodingData = await _geocodingService.GetGeocodingDataAsync(city, country);
		if (geocodingData == null) return null;

		var latitude = geocodingData.Latitude;
		var longitude = geocodingData.Longitude;

		// Get pollen forecast data
		try
		{
			var ApiKey = Environment.GetEnvironmentVariable("POLLEN_FORECAST_ENV") ?? throw new InvalidOperationException("API key not set.");
			var response = await _httpClient.GetStringAsync($"https://pollen.googleapis.com/v1/forecast:lookup?key={ApiKey}&location.longitude={longitude}&location.latitude={latitude}&days={days}");
			return JsonConvert.DeserializeObject<PollenForecast>(response);
		}
		catch (HttpRequestException ex)
		{
			Console.WriteLine($"Request error: {ex.Message}");
			return null;
		}
	}
}
