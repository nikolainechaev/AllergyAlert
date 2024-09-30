using Moq;
using allergyAPI.Services;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;
using Moq.Protected;
using System.Threading;
using System.Net;

public class GeocodingServiceTests
{
    private readonly HttpClient _httpClient;
    private readonly Mock<HttpMessageHandler> _httpMessageHandlerMock;

    public GeocodingServiceTests()
    {
        _httpMessageHandlerMock = new Mock<HttpMessageHandler>();
        _httpClient = new HttpClient(_httpMessageHandlerMock.Object);
    }

    [Fact]
    public async Task GetGeocodingDataAsync_ReturnsCorrectResult()
    {
        // Arrange
        var jsonResponse = "[{\"Latitude\": 40.7128, \"Longitude\": -74.0060}]";

        _httpMessageHandlerMock.Protected()
            .Setup<Task<HttpResponseMessage>>(
                "SendAsync",
                ItExpr.IsAny<HttpRequestMessage>(),
                ItExpr.IsAny<CancellationToken>())
            .ReturnsAsync(new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(jsonResponse)
            });

        var geocodingService = new GeocodingService(_httpClient);

        // Act
        var result = await geocodingService.GetGeocodingDataAsync("New York", "US");

        // Assert
        Assert.NotNull(result);
        Assert.Equal(40.7128, result?.Latitude);
        Assert.Equal(-74.0060, result?.Longitude);
    }
}
