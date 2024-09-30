using allergyAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace allergyAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllergyForecastController : ControllerBase
    {
        private readonly IGeocodingService _geocodingService;
        private readonly IPollenForecastService _pollenForecastService;
        private readonly IPlantInfoService _plantInfoService;

        public AllergyForecastController(IGeocodingService geocodingService, IPollenForecastService pollenForecastService, IPlantInfoService plantInfoService)
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

            var forecast = await _pollenForecastService.GetForecastAsync(city, country, days);

            if (forecast == null)
            {
                return NotFound(new { error = "Forecast data not found." });
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

            var plantInfo = await _plantInfoService.GetPlantInfoAsync(plant);

            if (plantInfo == null)
            {
                return NotFound(new { error = "Plant information not found." });
            }

            return Ok(plantInfo);
        }
    }
}
