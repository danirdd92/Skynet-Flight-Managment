using Repository;
using Skynet.Entities;
using Skynet.Entities.Models;

namespace Skynet.Repository
{
    public class FlightRepository : RepositoryBase<Flight>, IFlightRepository
    {
        public FlightRepository(SkynetContext repositoryContext) : base(repositoryContext)
        {
        }
    }

    public interface IFlightRepository { }
}
