using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skynet.Entities.Models
{
    [Table("Flights")]
    public class Flight
    {
        public Flight()
        {
            UserFlights = new HashSet<UserFlights>();
        }

        public int FlightId { get; set; }
        public Guid AirlineId { get; set; }
        public int OriginCountryId { get; set; }
        public int DestinationCountryId { get; set; }
        public DateTime Departure { get; set; }
        public DateTime Arrival { get; set; }

        public virtual Airline Airline { get; set; }
        public virtual Country DestinationCountry { get; set; }
        public virtual Country OriginCountry { get; set; }
        public virtual ICollection<UserFlights> UserFlights { get; set; }

        [NotMapped]
        public string FlightNumber {
            get
            {
                return $"{Airline.Abbreviation}-{FlightId}";
            } 
            private set 
            {
                FlightNumber = value; 
            } 
        }

        

    }
}
