using allergyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace allergyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyForecastController : ControllerBase
    {
        private readonly GeocodingService _geocodingService;
        private readonly PollenForecastService _pollenForecastService;
        private readonly PlantInfoService _plantInfoService;

        public AllergyForecastController(GeocodingService geocodingService, PollenForecastService pollenForecastService, PlantInfoService plantInfoService)
        {
            _geocodingService = geocodingService;
            _pollenForecastService = pollenForecastService;
            _plantInfoService = plantInfoService;
        }

        [HttpGet("getforecast")]
        public async Task<IActionResult> GetForecast(string city, int days, string country)
        {
            if (string.IsNullOrEmpty(city) || string.IsNullOrEmpty(country))
            {
                return BadRequest(new { error = "City and country are required." });
            }

            // Get geocoding data
            var geocodingData = await _geocodingService.GetGeocodingDataAsync(city, country);
            if (geocodingData == null)
            {
                return NotFound(new { error = "Geocoding data not found." });
            }

            var latitude = geocodingData.Latitude;
            var longitude = geocodingData.Longitude;

            // Get pollen forecast data
            var forecast = await _pollenForecastService.GetPollenForecastAsync(latitude, longitude, days);

            if (forecast == null)
            {
                return NotFound(new { error = "Pollen forecast data not found." });
            }

            return Ok(forecast);
        }

        [HttpGet("getplantinfo")]
        public async Task<IActionResult> GetPlantInfo(string plant)
        {
            if (string.IsNullOrEmpty(plant))
            {
                return BadRequest(new { error = "The plant field is required." });
            }

            var plantInfo = await _plantInfoService.GetPlantImageUrlAsync(plant);

            if (plantInfo == null)
            {
                return NotFound(new { error = "Plant information not found." });
            }

            return Ok(plantInfo);
        }

    }
}
