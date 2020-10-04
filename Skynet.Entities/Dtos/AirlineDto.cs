using Skynet.Entities.Models;

namespace Skynet.Entities.Dtos
{
    public class AirlineDto
    {
        public string Name { get; set; }
        public string Abbreviation { get; set; }
        public CountryDto Country { get; set; }
    }


}
