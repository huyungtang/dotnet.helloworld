using dotnet.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace dotnet.Controllers
{
  [Route("[controller]")]
  [AllowAnonymous]
  public class WeatherForecastController : ControllerBase
  {
    private static readonly string[] Summaries = new[]
    {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
      _logger = logger;
    }

    [HttpGet("{records?}")]
    public IEnumerable<WeatherForecast> Get([FromQuery] WeatherForecast query, int records = 5)
    {
      return Enumerable.Range(1, records)
          .Select(index => new WeatherForecast
          {
            Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)],
            TempTime = DateTimeOffset.Now.ToUnixTimeMilliseconds(),
          })
          .ToArray();
    }

    [HttpPost("validation")]
    public IEnumerable<ValidationDTO> Validation([FromBody] ValidationDTO dto)
    {
      dto.Username = $"Username / {dto.Password}";

      dto.TelephoneUser = [
        new ValidationDTO.Telephone{ Content = "0234567890" },
        new ValidationDTO.Telephone{ Content = "0987654321" },
      ];

      return [dto];
    }
  }
}
