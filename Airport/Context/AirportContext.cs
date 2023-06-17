using Airport.Models;
using Microsoft.EntityFrameworkCore;

namespace Airport.Context
{
    public class AirportContext : DbContext
    {
        public DbSet<Passenger> Passengers { get; set; } = null!;
        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<Flight> Flights { get; set; } = null!;
        public AirportContext() => Database.EnsureCreated();
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Airport_sqlite.db");
        }
    }
}
