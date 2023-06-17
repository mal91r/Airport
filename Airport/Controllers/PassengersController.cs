using Airport.Context;
using Microsoft.AspNetCore.Mvc;
using Airport.Models;

namespace Airport.Controllers
{
    [Controller]
    [Route("passengers")]
    public class PassengersController : Controller
    {
        [HttpPost("add")]
        public IActionResult Add()
        {
            var passenger = new Passenger();
            using (AirportContext context = new AirportContext())
            {
                context.Passengers.Add(passenger);
                context.SaveChanges();
            }
            return Ok(passenger.Id);
        }

        [HttpGet]
        public IActionResult GetPassengers()
        {

            using (AirportContext context = new AirportContext())
            {
                var passengers = context.Passengers.ToList();
                if (passengers.Any())
                {
                    return Ok(passengers);
                }
                else
                {
                    return NotFound();
                }
            }
        }
    }
}
