using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace allergyAPI.Services
{
	public class PlantInfoService
	{
		private readonly HttpClient _httpClient;

		public PlantInfoService(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<string> GetPlantImageUrlAsync(string query)
		{
			try
			{
				var ApiKey = Environment.GetEnvironmentVariable("PLANT_INFO_ENV") ?? throw new InvalidOperationException("API key not set.");
				var response = await _httpClient.GetAsync($"http://perenual.com/api/species-list?key={ApiKey}&q={query}");
				response.EnsureSuccessStatusCode();

				var content = await response.Content.ReadAsStringAsync();
				// Console.WriteLine($"Response content: {content}");

				var plantApiResponse = JsonConvert.DeserializeObject<PlantApiResponse>(content);

				if (plantApiResponse?.Data == null || !plantApiResponse.Data.Any())
				{
					Console.WriteLine("No plant information found.");
					return null;
				}

				var plant = plantApiResponse.Data.FirstOrDefault();

				if (plant == null || plant.DefaultImage == null)
				{
					Console.WriteLine("Plant information is incomplete or missing image data.");
					return null;
				}

				// Return the original_url from the DefaultImage
				return plant.DefaultImage.OriginalUrl;
			}
			catch (HttpRequestException ex)
			{
				Console.WriteLine($"Request error: {ex.Message}");
				return null;
			}
			catch (JsonSerializationException ex)
			{
				Console.WriteLine($"Serialization error: {ex.Message}");
				return null;
			}
			catch (Exception ex)
			{
				Console.WriteLine($"Unexpected error: {ex.Message}");
				return null;
			}
		}
	}

	public class PlantApiResponse
	{
		public List<PlantData>? Data { get; set; }
	}

	public class PlantData
	{
		[JsonProperty("id")]
		public int? Id { get; set; }

		[JsonProperty("common_name")]
		public string? CommonName { get; set; }

		[JsonProperty("scientific_name")]
		public List<string>? ScientificName { get; set; }

		[JsonProperty("other_name")]
		public List<string>? OtherName { get; set; }

		[JsonProperty("cycle")]
		public string? Cycle { get; set; }

		[JsonProperty("watering")]
		public string? Watering { get; set; }

		[JsonProperty("sunlight")]
		public object? Sunlight { get; set; }

		[JsonProperty("default_image")]
		public DefaultImage? DefaultImage { get; set; }

		public string? OriginalUrl => DefaultImage?.OriginalUrl;

		public List<string> GetSunlightAsList()
		{
			if (Sunlight is List<string> list)
			{
				return list;
			}
			else if (Sunlight is string str)
			{
				return new List<string> { str };
			}
			return new List<string>();
		}
	}

	public class DefaultImage
	{
		[JsonProperty("license")]
		public int? License { get; set; }

		[JsonProperty("license_name")]
		public string? LicenseName { get; set; }

		[JsonProperty("license_url")]
		public string? LicenseUrl { get; set; }

		[JsonProperty("original_url")]
		public string? OriginalUrl { get; set; }

		[JsonProperty("regular_url")]
		public string? RegularUrl { get; set; }

		[JsonProperty("medium_url")]
		public string? MediumUrl { get; set; }

		[JsonProperty("small_url")]
		public string? SmallUrl { get; set; }

		[JsonProperty("thumbnail")]
		public string? Thumbnail { get; set; }
	}

}
