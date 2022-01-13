using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationExample.Tests.Api.Models
{
    public class WeatherData
    {
        public DateTime Date { get; set; }
        public int Temprature { get; set; }
        public int WindSpeed { get; set; }
        public int WindDirection { get; set; }
        public string Units { get; set; }
        public string Summary { get; set; }
    }
}
