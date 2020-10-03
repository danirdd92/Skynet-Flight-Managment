using Repository;
using Skynet.Entities;
using Skynet.Entities.Models;

namespace Skynet.Repository
{
    public class AirlineRepository : RepositoryBase<Airline>, IAirlineRepository
    {
        public AirlineRepository(SkynetContext repositoryContext) : base(repositoryContext)
        {
        }
    }

    public interface IAirlineRepository { }
}
