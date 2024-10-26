// using Microsoft.AspNetCore.Mvc;
//
// namespace NZWalks.API.Controller
// {
//     [ApiController]
//     [Route("[controller]")]
//
//     public class WeatherForecastController : ControllerBase
//     {
//         
//         
//         
//     private static readonly string[] summaries = new[] {
//     "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
// };
//     
//     private readonly ILogger<WeatherForecastController> _logger;
//
//     public WeatherforecastController(ILogger<WeatherForecastController> logger)
//     {
//         _logger = logger;
//     }
//
//     [HttpGet(Name = "GetWeatherForecast")]
//     public IEnumerable<WeatherForecast> Get()
//     {
//         return Enumerable.Range(1,5).Select(Index => new WeatherForecast)
//     }
//     
//
// // app.MapGet("/weatherforecast", () =>
// //     {
// //         var forecast = Enumerable.Range(1, 5).Select(index =>
// //                 new WeatherForecast
// //                 (
// //                     DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
// //                     Random.Shared.Next(-20, 55),
// //                     summaries[Random.Shared.Next(summaries.Length)]
// //                 ))
// //             .ToArray();
// //         return forecast;
// //     })
// //     .WithName("GetWeatherForecast")
// //     .WithOpenApi();
// //
// //     }
// }
//
//
