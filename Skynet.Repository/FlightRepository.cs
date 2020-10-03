using Repository;
using Skynet.Entities;
using Skynet.Entities.Models;

namespace Skynet.Repository
{
    public class FlightRepository : RepositoryBase<Flight>
    {
        public FlightRepository(SkynetContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
