using AutomationExample.Web.Extensions;
using AutomationExample.Web.Model;
using Microsoft.AspNetCore.Mvc;

namespace AutomationExample.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
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


        [HttpGet(Name = "GetWeatherForecast")]
        public Result<IEnumerable<WeatherForecast>> Get()
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

            _logger.LogInformation($"{returnData.ToJson()}");

            return returnData;
        }

        [HttpPost(Name = "PostWeatherData")]
        public Result<WeatherData> Post(WeatherData data)
        {
            _logger.LogInformation("Post Method Called");
            _logger.LogInformation($"{data.ToJson()}");

            return new Result<WeatherData>() { Data = data };
        }
    }
}