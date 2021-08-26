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
        private readonly IMapper _mapper;

        public WeatherForecastController(WeatherDbContext context)
        {
            _context = context;
            _mapper = new MapperConfiguration(opt => opt.AddProfile<WeatherForecastMapperProfile>()).CreateMapper();
        }

        [HttpGet("odata/weatherforecasts")]
        [EnableQuery]
        /*ProjectTo apparently doesn't work in 7.5.8 and $count doesn't work in 8.0.1 so I am fucked... nice*/
        public /*IQueryable<WeatherForecastDto>*/ IEnumerable<WeatherForecast> Get() => /*_mapper.ProjectTo<WeatherForecastDto>(_context.WeatherForecasts.AsQueryable());*/ _context.WeatherForecasts.AsQueryable();

    }
}
