using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Skynet.Entities.Models
{
    [Table("Airlines")]
    public class Airline
    {
        public Airline()
        {
            Flights = new HashSet<Flight>();
        }

        public Guid AirlineId { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public int? CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual ICollection<Flight> Flights { get; set; }
    }
}
