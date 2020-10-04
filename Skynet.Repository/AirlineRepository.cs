using Microsoft.EntityFrameworkCore;
using Repository;
using Skynet.Entities;
using Skynet.Entities.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skynet.Repository
{
    public class AirlineRepository : RepositoryBase<Airline>, IAirlineRepository
    {
        public AirlineRepository(SkynetContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Airline>> GetAirlineByCountryAsync(int id, bool trackChanges)
        {
            var result = await FindByCondition(c => c.CountryId.Equals(id), trackChanges)
                .Include(c => c.Country)
                .ToListAsync();

            return result;
        }

        public IEnumerable<Airline> GetAllAirlines()
        {
            return FindAll(false).Include(c => c.Country);
        }
    }

    public interface IAirlineRepository
    {
        Task<IEnumerable<Airline>> GetAirlineByCountryAsync(int id, bool trackChanges);
        IEnumerable<Airline> GetAllAirlines();
    }
}
