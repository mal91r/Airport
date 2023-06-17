using Microsoft.AspNetCore.Mvc;
using Airport.Models;
using Airport.Context;

namespace Airport.Controllers
{
    [Controller]
    [Route("tickets")]
    public class TicketsController : Controller
    {
        [HttpPost]
        public IActionResult Buy(int flightId, int passengerId)
        {
            using (AirportContext context = new AirportContext())
            {
                var flight = context.Flights.FirstOrDefault(f => f.Id == flightId);
                if (flight == null)
                {
                    return NotFound();
                }
                var passenger = context.Passengers.FirstOrDefault(p => p.Id == passengerId);
                if (passenger == null)
                {
                    return NotFound();
                }
                var ticket = new Ticket
                {
                    PassengerId = passengerId,
                    FlightId = flightId,
                };
                context.Tickets.Add(ticket);
                context.SaveChanges();
                return Ok(ticket);
            }
        }

        [HttpGet("{passengerId}")]
        public IActionResult GetTicketsByPassenger([FromRoute] int passengerId)
        {
            using (AirportContext context = new AirportContext())
            {
                var passenger = context.Passengers.FirstOrDefault(p => p.Id == passengerId);
                if (passenger == null)
                {
                    return NotFound();
                }
                var ticket = context.Tickets.Where(t => t.PassengerId == passengerId).ToList();
                return Ok(ticket);
            }
        }

        [HttpDelete("{ticketId}")]
        public IActionResult DeleteTicket([FromRoute] int ticketId)
        {
            using (AirportContext context = new AirportContext())
            {
                var ticket = context.Tickets.FirstOrDefault(t => t.Id == ticketId);
                if(ticket == null)
                {
                    return NotFound();
                }
                context.Tickets.Remove(ticket);
                context.SaveChanges(true);
                return Ok(ticket);
            }
        }
    }
}
