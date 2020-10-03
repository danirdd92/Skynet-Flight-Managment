using Repository;
using Skynet.Entities;
using Skynet.Entities.Models;

namespace Skynet.Repository
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(SkynetContext context) : base(context)
        {
        }
    }

    public interface ICountryRepository { }
}
