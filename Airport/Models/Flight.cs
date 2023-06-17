namespace Airport.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string? DeparturePoint { get; set; }
        public string? ArrivalPoint { get; set; }
        public TimeSpan DepartureTime { get; set; }
        public TimeSpan ArrivalTime { get; set; }
    }
}
