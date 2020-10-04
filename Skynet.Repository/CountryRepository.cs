using Repository;
using Skynet.Entities;
using Skynet.Entities.Models;
using System.Collections;
using System.Collections.Generic;

namespace Skynet.Repository
{
    public class CountryRepository : RepositoryBase<Country>, ICountryRepository
    {
        public CountryRepository(SkynetContext context) : base(context)
        {
        }

        public IEnumerable<Country> GetAllCountries()
        {
            return FindAll(false);
        }
    }

    public interface ICountryRepository
    {

        public IEnumerable<Country> GetAllCountries();
    }
}
