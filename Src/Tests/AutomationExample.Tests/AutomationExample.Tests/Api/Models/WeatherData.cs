using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace AutomationExample.Tests.Api.Models
{
    public class WeatherData
    {
        [JsonPropertyName("date")]
        public DateTime Date { get; set; }
        [JsonPropertyName("temprature")]
        public int Temprature { get; set; }
        [JsonPropertyName("windSpeed")]
        public int WindSpeed { get; set; }
        [JsonPropertyName("windDirection")]
        public int WindDirection { get; set; }
        [JsonPropertyName("units")]
        public string Units { get; set; }
        [JsonPropertyName("summary")]
        public string Summary { get; set; }
    }
}
