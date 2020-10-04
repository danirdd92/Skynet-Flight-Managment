using Skynet.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Entities.Dtos
{
    public class FlightDto
    {
        public string FlightNumber { get; set; }
        public AirlineDto Airline { get; set; }
        public CountryDto OriginCountry { get; set; }
        public DateTime Departure { get; set; }
        public CountryDto DestinationCountry { get; set; }
        public DateTime Arrival { get; set; }

    }
}
