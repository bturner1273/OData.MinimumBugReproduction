using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OData.MinimumBugReproduction
{
    public class WeatherForecastMapperProfile : Profile
    {
        public WeatherForecastMapperProfile()
        {
            CreateMap<WeatherForecast, WeatherForecastDto>()
                .ReverseMap();
        }
    }
}
