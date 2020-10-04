using System;

namespace Skynet.Entities.Models
{
    public class UserFlights
    {
        public string UserId { get; set; }
        public int FlightId { get; set; }

        public virtual Flight Flight { get; set; }
        public virtual User User { get; set; }
    }
}
