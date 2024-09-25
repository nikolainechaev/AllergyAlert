using Newtonsoft.Json;
using System.Collections.Generic;

namespace allergyAPI.Models
{
	public class PlantInfoResponse
	{
		public string? CommonName { get; set; }
		public List<string>? ScientificName { get; set; }
		public string? Cycle { get; set; }
		public string? ImageUrl { get; set; }
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
