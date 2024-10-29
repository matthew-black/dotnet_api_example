using Microsoft.AspNetCore.Mvc;

namespace ContosoPizza.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    // The Dummy Data for weather summaries:
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();
    }

    // router.get('/', (req, res) => {
    //    Generate an array of forecast objects that looks like this:
    //    let forecasts = [
          // {
            // "date": "2024-09-19",
            // "temperatureC": -4,
            // "temperatureF": 25,
            // "summary": "Cool"
          // },
          // {
            // "date": "2024-09-20",
            // "temperatureC": 52,
            // "temperatureF": 125,
            // "summary": "Hot"
          // }
    //    ]

    // res.send(forecasts)
    
    //})
}
