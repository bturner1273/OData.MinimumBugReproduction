using AutoMapper;
using Microsoft.AspNet.OData;
using Microsoft.AspNet.OData.Routing;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace OData.MinimumBugReproduction.Controllers
{
    [ODataRoutePrefix("WeatherForecasts")]
    public class WeatherForecastController : ODataController
    {
        private readonly WeatherDbContext _context;

        public WeatherForecastController(WeatherDbContext context)
        {
            _context = context;
        }

        [HttpGet("odata/weatherforecasts")]
        [EnableQuery]
        public IEnumerable<WeatherForecast> Get() => _context.WeatherForecasts;
    }
}
