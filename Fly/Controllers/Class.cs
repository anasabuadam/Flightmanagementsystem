using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;
namespace Fly.Controllers
{


    [ApiController]
    [Route("[controlleer]")]
    public class Class : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public Class(ILogger<Class> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Class")]
        public IEnumerable<Fly.Class> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new Class 
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
