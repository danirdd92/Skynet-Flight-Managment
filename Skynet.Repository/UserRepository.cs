using Microsoft.EntityFrameworkCore;
using Repository;
using Skynet.Entities;
using Skynet.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Skynet.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(SkynetContext context) : base(context)
        {
        }

        public async Task<IEnumerable<User>> GetUserByFirstNameAsync(string firstName, bool trackChanges)
        {
            var user = await FindByCondition(u => u.FirstName.ToLower().Equals(firstName.ToLower()),
                trackChanges).ToListAsync();

            return user;
        }
    }

    public interface IUserRepository {
        Task<IEnumerable<User>> GetUserByFirstNameAsync(string firstName, bool trackChanges);
    }
}
