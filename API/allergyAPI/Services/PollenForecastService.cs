using Newtonsoft.Json;

public class PollenForecastService
{
	private readonly HttpClient _httpClient;

	public PollenForecastService(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<PollenForecast> GetPollenForecastAsync(double latitude, double longitude, int days)
	{
		var ApiKey = Environment.GetEnvironmentVariable("POLLEN_FORECAST_ENV") ?? throw new InvalidOperationException("API key not set.");
		var response = await _httpClient.GetStringAsync($"https://pollen.googleapis.com/v1/forecast:lookup?key={ApiKey}&location.longitude={longitude}&location.latitude={latitude}&days={days}");
		return JsonConvert.DeserializeObject<PollenForecast>(response);
	}
}
