using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tryitter.Api.Database;
using Tryitter.Api.Models;

namespace Tryitter.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
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

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
            Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        })
        .ToArray();

        //var tryitterContext = new TryitterContext();

        //tryitterContext.Database.EnsureCreated();

        //var moduleOne = new Module() { Name = "Fundamentos" };
        //var moduleTwo = new Module() { Name = "Front-End" };

        //tryitterContext.Modules.Add(moduleOne);
        //tryitterContext.Modules.Add(moduleTwo);
        //tryitterContext.SaveChanges();

        //return tryitterContext.Modules.ToArray();

        // GET /students
        // GET /students/{id}
        // GET /students?name=
        // POST /students
        // PUT /students/{id}
        // DELETE /students/{id}

        // POST /login

        // GET /posts
        // GET /posts/last
        // GET /posts/{id}
        // POST /posts
        // PUT /posts/{id}
        // DELETE /posts/{id}

        // GET /posts?name=
        // GET /posts/last?name=
    }
}
