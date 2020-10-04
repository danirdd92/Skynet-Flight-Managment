using Microsoft.EntityFrameworkCore;
using Repository;
using Skynet.Entities;
using Skynet.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skynet.Repository
{
    public class FlightRepository : RepositoryBase<Flight>, IFlightRepository
    {
        public SkynetContext _context;
        public FlightRepository(SkynetContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Flight>> GetFlightsByDepartureDateAsync(DateTime departureDate, bool trackChanges)
        {
            var flights = await FindByCondition(f => f.Departure.Date.Equals(departureDate.Date),
                trackChanges).ToListAsync();
            return flights;
        }

        public async Task<IEnumerable<Flight>> GetFlightsByDestinationAsync(string countryName, bool trackChanges)
        {
            var flights = await FindByCondition(f => f.DestinationCountry.Name.ToLower().Equals(countryName.ToLower()),
                trackChanges).ToListAsync();
            return flights;
        }

        public async Task<IEnumerable<Flight>> GetFlightsByArrivalDateAsync(DateTime arrivalDate, bool trackChanges)
        {
            var flights = await FindByCondition(f => f.Arrival.Date.Equals(arrivalDate.Date),
                trackChanges).ToListAsync();
            return flights;
        }

        public async Task<IEnumerable<Flight>> GetFlightsByOriginCountryAsync(string countryName, bool trackChanges)
        {
            var flights = await FindByCondition(f => f.OriginCountry.Name.ToLower().Equals(countryName.ToLower()),
                trackChanges).ToListAsync();
            return flights;
        }

        public async Task<IEnumerable<Flight>> GetFlightsByUserAsync(string userId, bool trackChanges)
        {
            var flights = await FindAll(trackChanges)
                .Where(f => f.UserFlights.Contains(new UserFlights { UserId = userId }))
                .ToListAsync();
            return flights; // I have a bad feeling about this

        }

        public async Task<IEnumerable<Flight>> GetUpcomingFlightsAsync(bool trackChanges)
        {
            var now = DateTime.Now;
            var upcomingFlights = await FindByCondition(f => f.Departure > now, trackChanges)
                        .OrderBy(t => t.Departure).Take(10).ToListAsync();

            return upcomingFlights;
        }
    }

    public interface IFlightRepository
    {
        Task<IEnumerable<Flight>> GetFlightsByUserAsync(string userId, bool trackChanges);
        Task<IEnumerable<Flight>> GetFlightsByArrivalDateAsync(DateTime landingDate, bool trackChanges);
        Task<IEnumerable<Flight>> GetFlightsByDepartureDateAsync(DateTime departureDate, bool trackChanges);
        Task<IEnumerable<Flight>> GetFlightsByOriginCountryAsync(string countryName, bool trackChanges);
        Task<IEnumerable<Flight>> GetFlightsByDestinationAsync(string countryName, bool trackChanges);
        Task<IEnumerable<Flight>> GetUpcomingFlightsAsync(bool trackChanges);
    }
}
