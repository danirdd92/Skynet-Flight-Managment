using Repository;
using Skynet.Entities;
using Skynet.Entities.Models;

namespace Skynet.Repository
{
    public class CountryRepository : RepositoryBase<Country>
    {
        public CountryRepository(SkynetContext repositoryContext) : base(repositoryContext)
        {
        }
    }
}
