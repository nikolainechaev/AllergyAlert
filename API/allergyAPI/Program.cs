using allergyAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add your custom services for the allergy forecast app
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("SpecificOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:4200")
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


builder.Services.AddHttpClient<GeocodingService>(client =>
{
    var ApiKey = Environment.GetEnvironmentVariable("GEOCODING_ENV") ?? throw new InvalidOperationException("API key not set.");
    client.DefaultRequestHeaders.Add("x-api-key", ApiKey);

});
builder.Services.AddHttpClient<PollenForecastService>();
builder.Services.AddHttpClient<PlantInfoService>();

var app = builder.Build();
app.UseCors("SpecificOrigins");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseHttpsRedirection();
}

// Uncomment if you want to enforce HTTPS in all environments
// app.UseHttpsRedirection();

// Map the controller routes
app.MapControllers();

// Example of your existing code, for reference
var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
