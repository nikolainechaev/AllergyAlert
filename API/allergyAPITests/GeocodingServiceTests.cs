using allergyAPI.Services;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

public class GeocodingServiceTests
{
    private readonly HttpClient _httpClient;

    public GeocodingServiceTests()
    {
        _httpClient = new HttpClient();
    }

    [Fact]
    public async Task GetGeocodingDataAsync_ReturnsCorrectResult()
    {
        // Arrange
        IGeocodingService geocodingService = new GeocodingService(_httpClient);

        // Act
        var result = await geocodingService.GetGeocodingDataAsync("New York", "US");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(40.7127281, result?.Latitude);
        Assert.Equal(-74.006015199999993, result?.Longitude);
    }
}