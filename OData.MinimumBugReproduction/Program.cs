using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OData.MinimumBugReproduction
{
    public class Program
    {

        private static readonly string[] Summaries = new[]
{
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private static Random rand = new Random();
        
        private static DateTime GetRandomDayAfterJanuaryFirst1970()
        {
            DateTime start = new DateTime(1970, 1, 1);
            int range = (DateTime.Today - start).Days;
            return start.AddDays(rand.Next(range));
        }

        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var sp = scope.ServiceProvider;
                var context = sp.GetRequiredService<WeatherDbContext>();
                context.WeatherForecasts.AddRange(Enumerable.Range(1, 100).Select(idx => new WeatherForecast
                {
                    Id = idx,
                    Date = GetRandomDayAfterJanuaryFirst1970(),
                    TemperatureC = rand.Next(-20, 55),
                    Summary = Summaries[rand.Next(Summaries.Length)]
                }));
                context.SaveChanges();
            }

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
