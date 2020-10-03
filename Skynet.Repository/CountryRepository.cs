using Repository;
using Skynet.Entities;
using Skynet.Entities.Models;

namespace Skynet.Repository
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(SkynetContext repositoryContext) : base(repositoryContext)
        {
        }
    }

    public interface ICountryRepository { }
}
