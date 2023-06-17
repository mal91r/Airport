using Microsoft.AspNetCore.Mvc;
using Airport.Models;
using Airport.Context;

namespace Airport.Controllers
{
    [Controller]
    [Route("flights")]
    public class FlightsController : Controller
    {
        [HttpPost("add")]
        public IActionResult Add(string? departurePoint, string? arrivalPoint, string? departureDate, string? arrivalDate)
        {
            TimeSpan departureTime, arrivalTime;
            if (!TimeSpan.TryParse(departureDate, out departureTime))
            {
                return BadRequest();
            }
            if (!TimeSpan.TryParse(arrivalDate, out arrivalTime))
            {
                return BadRequest();
            }

            var flight = new Flight
            {
                DeparturePoint = departurePoint,
                ArrivalPoint = arrivalPoint,
                DepartureTime = departureTime,
                ArrivalTime = arrivalTime
            };
            using (AirportContext context = new AirportContext())
            {
                context.Flights.Add(flight);
                context.SaveChanges();
            }
            return Ok(flight.Id);
        }

        [HttpGet]
        public IActionResult GetFlights()
        {
            using (AirportContext context = new AirportContext())
            {
                return Ok(context.Flights.ToList());
            }
        }
    }
}
