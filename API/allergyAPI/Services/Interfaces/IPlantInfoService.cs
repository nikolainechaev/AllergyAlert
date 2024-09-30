using allergyAPI.Models;
using System.Threading.Tasks;

public interface IPlantInfoService
{
	Task<PlantInfoResponse?> GetPlantInfoAsync(string plantName);
	Task<PlantInfoResponse?> FetchPlantInfoFromApiAsync(string plantName);
}