using allergyAPI.Models;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

public class PlantInfoService : IPlantInfoService
{
	private readonly HttpClient _httpClient;
	private readonly IMemoryCache _memoryCache;
	private static readonly TimeSpan CacheDuration = TimeSpan.FromMinutes(30); // Customize cache duration

	public PlantInfoService(HttpClient httpClient, IMemoryCache memoryCache)
	{
		_httpClient = httpClient;
		_memoryCache = memoryCache;
	}

	public async Task<PlantInfoResponse?> GetPlantInfoAsync(string plantName)
	{
		// Try to get the plant info from the cache
		if (_memoryCache.TryGetValue(plantName, out PlantInfoResponse cachedPlantInfo))
		{
			return cachedPlantInfo;
		}

		// If not in cache, fetch from API
		var plantInfo = await FetchPlantInfoFromApiAsync(plantName);

		if (plantInfo != null)
		{
			// Cache the plant info
			_memoryCache.Set(plantName, plantInfo, CacheDuration);
		}

		return plantInfo;
	}

	private async Task<PlantInfoResponse?> FetchPlantInfoFromApiAsync(string plantName)
	{
		// Logic to fetch plant information from external API
		var ApiKey = Environment.GetEnvironmentVariable("PLANT_INFO_ENV") ?? throw new InvalidOperationException("API key not set.");
		var response = await _httpClient.GetAsync($"http://perenual.com/api/species-list?key={ApiKey}&q={plantName}");
		response.EnsureSuccessStatusCode();

		var content = await response.Content.ReadAsStringAsync();
		var plantApiResponse = JsonConvert.DeserializeObject<PlantApiResponse>(content);

		if (plantApiResponse?.Data == null || !plantApiResponse.Data.Any())
		{
			return null;
		}

		var plant = plantApiResponse.Data.FirstOrDefault();
		return new PlantInfoResponse
		{
			CommonName = plant.CommonName,
			ScientificName = plant.ScientificName,
			Cycle = plant.Cycle,
			ImageUrl = plant.DefaultImage?.OriginalUrl
		};
	}

	Task<PlantInfoResponse?> IPlantInfoService.FetchPlantInfoFromApiAsync(string plantName)
	{
		throw new NotImplementedException();
	}
}
