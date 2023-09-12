using DotNetWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private static List<Airport> airports = new List<Airport>
            {
                new Airport {
                    Id = 1,
                    Name = "Ratanaba International",
                    AirportType = "Public",
                    City = "Ratanaba/MT Brazil",
                    Coordinates = "-8.134411, -57.896092",
                    TimeZone= -3,
                    Website= "https://pt.wikipedia.org/wiki/Ratanab%C3%A1"
                }
        };

        [HttpGet]
        public async Task<ActionResult<List<Airport>>> Get()
        {
            return Ok(airports);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Airport>> Get(int id)
        {
            var airport = airports.Find(a => a.Id == id);
            if (airport == null)
            {
                return NotFound();
            }
            return Ok(airport);
        }

        [HttpPost]
        public async Task<ActionResult<Airport>> Create(Airport airport)
        {
            airports.Add(airport);
            // get uri from inserted airport
            return CreatedAtAction(nameof(Get), new { id = airport.Id }, airport);
        }
    }
}
