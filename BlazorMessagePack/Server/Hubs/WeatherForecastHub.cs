// ===========================
// BlazorSpread.net
// ===========================
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

        static int _i;

        public async Task GenerateReport(int rows)
        {
            System.Diagnostics.Trace.WriteLine($"Call: {++_i}");

            var forecasts = Enumerable.Range(1, rows).Select(index => new WeatherForecast {
                Date = DateTime.UtcNow.AddMinutes(index),
                TemperatureC = _random.Next(-20, 55),
                Summary = Summaries[_random.Next(Summaries.Length)]
            });

            var report = new WeatherReport {
                ReportDate = DateTime.UtcNow,
                Forecasts = forecasts
            };

            await Clients.All.SendAsync("Report", report);
        }
    }
}
