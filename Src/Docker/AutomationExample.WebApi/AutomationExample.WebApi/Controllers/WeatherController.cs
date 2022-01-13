using AutomationExample.WebApi.Extensions;
using AutomationExample.WebApi.Model;
using Microsoft.AspNetCore.Mvc;

namespace AutomationExample.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }
        
        [HttpGet("WeatherForecast")]
        public async Task<ActionResult<Result<IEnumerable<WeatherForecast>>>> WeatherForecast()
        {
            _logger.LogInformation("Get Method Called");

            Result<IEnumerable<WeatherForecast>> returnData = new Result<IEnumerable<WeatherForecast>>
            {
                Data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
                    {
                        Date = DateTime.Now.AddDays(index),
                        TemperatureC = Random.Shared.Next(-20, 55),
                        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
                    })
                    .ToArray()
            };

            _logger.LogInformation($"{await returnData.ToJsonAsync()}");

            return returnData;
        }

        [HttpPost("WeatherData")]
        public async Task<ActionResult<Result<WeatherData>>> WeatherData([FromBody] string weatherData)
        {
            _logger.LogInformation("Post Method Called");
            _logger.LogInformation($"{await weatherData.ToJsonAsync()}");

            return new Result<WeatherData>() { Data = weatherData.FromJson<WeatherData>() };
        }
    }
}