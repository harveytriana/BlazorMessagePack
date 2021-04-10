using BlazorMessagePack.Shared;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorMessagePack.Server.Hubs
{
    public class WeatherForecastHub : Hub
    {
        static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        static readonly Random _random = new();

        public async Task GenerateReport(int rows)
        {
            var forecasts = Enumerable.Range(1, rows).Select(index => new WeatherForecast {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = _random.Next(-20, 55),
                Summary = Summaries[_random.Next(Summaries.Length)]
            });

            var report = new WeatherReport {
                StampTime = DateTime.UtcNow,
                Forecasts = forecasts
            };

            await Clients.All.SendAsync("Report", report);
        }
    }
}
