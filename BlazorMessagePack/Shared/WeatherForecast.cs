using System;
using System.Collections.Generic;
using System.Text;

namespace BlazorMessagePack.Shared
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }
        public int TemperatureC { get; set; }
        public string Summary { get; set; }
        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
    }

    public class WeatherReport
    {
        public DateTime ReportDate { get; set; }
        public IEnumerable<WeatherForecast> Forecasts { get; set; }
    }
}
