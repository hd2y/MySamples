using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace _210906_Autofac.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromServices] IServiceProvider provider)
        {
            var db = provider.GetRequiredService<IFreeSql>();
            var db1 = provider.GetRequiredService<IFreeSql<Db1>>();
            var db2 = provider.GetRequiredService<IFreeSql<Db2>>();
            var testService = provider.GetRequiredService<TestService>();
            return new JsonResult(
                new
                {
                    Method = new[]
                    {
                        db?.GetType().FullName, db1?.GetType().FullName, db2?.GetType().FullName
                    },
                    Property = new[]
                    {
                        testService.Db?.GetType().FullName, testService.Db1?.GetType().FullName,
                        testService.Db2?.GetType().FullName
                    }
                }
            );
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray();
        }
    }
}