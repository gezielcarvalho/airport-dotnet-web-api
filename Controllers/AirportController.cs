using DotNetWebApi.Data;
using DotNetWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;

namespace DotNetWebApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AirportController : ControllerBase
    {
        private readonly DataContext _context;
        public AirportController(DataContext context)
        {
            _context = context;
        }

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
            return Ok(await _context.Airports.ToListAsync());
        }

        [HttpGet]
        [Route("/test")]
        public ActionResult<AnyType> GetTest()
        {
            var message = new OpenApiString("Hello World");
            return Ok(message);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Airport>> Get(int id)
        {
            var airport = await _context.Airports.FindAsync(id);
            if (airport == null)
            {
                return NotFound();
            }
            return Ok(airport);
        }

        [HttpPost]
        public async Task<ActionResult<Airport>> Create(Airport airport)
        {
            _context.Airports.Add(airport);
            await _context.SaveChangesAsync();
            // get uri from inserted airport
            return CreatedAtAction(nameof(Get), new { id = airport.Id }, airport);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, Airport airport)
        {
            if (id != airport.Id)
            {
                return BadRequest();
            }
            var airportToUpdate = await _context.Airports.FindAsync(id);
            if (airportToUpdate == null)
            {
                return NotFound();
            }

            airportToUpdate.AirportType = airport.AirportType;
            airportToUpdate.Coordinates = airport.Coordinates;
            airportToUpdate.Website = airport.Website;
            airportToUpdate.TimeZone = airport.TimeZone;
            airportToUpdate.Name = airport.Name;
            airportToUpdate.City = airport.City;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var airport = await _context.Airports.FindAsync(id);
            if (airport == null)
            {
                return NotFound();
            }
            _context.Airports.Remove(airport);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
