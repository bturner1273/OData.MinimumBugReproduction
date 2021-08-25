using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OData.MinimumBugReproduction.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherDbContext _context;

        public WeatherForecastController(WeatherDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get() =>  _context.WeatherForecasts;

        [HttpGet("odata")]
        [EnableQuery]
        public IEnumerable<WeatherForecast> ODataGet() => _context.WeatherForecasts;

    }
}
