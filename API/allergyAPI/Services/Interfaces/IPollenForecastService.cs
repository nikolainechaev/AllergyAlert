using allergyAPI.Models;
using System.Threading.Tasks;

public interface IPollenForecastService
{
	Task<PollenForecast?> GetForecastAsync(string city, string country, int days);
}