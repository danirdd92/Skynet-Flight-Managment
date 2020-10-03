using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Skynet.Entities.Models
{
    [Table("Countries")]
    public class Country
    {
        public Country()
        {
            Airline = new HashSet<Airline>();
            FlightsDestinationCountry = new HashSet<Flight>();
            FlightsOriginCountry = new HashSet<Flight>();
        }

        public int CountryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Airline> Airline { get; set; }
        public virtual ICollection<Flight> FlightsDestinationCountry { get; set; }
        public virtual ICollection<Flight> FlightsOriginCountry { get; set; }
    }
}
