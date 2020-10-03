﻿using Repository;
using Skynet.Entities;
using Skynet.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(SkynetContext repositoryContext) : base(repositoryContext)
        {
        }
    }

    public interface IUserRepository { }
}
