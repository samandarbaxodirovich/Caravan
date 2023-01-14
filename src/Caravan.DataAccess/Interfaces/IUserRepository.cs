﻿using Caravan.DataAccess.Interfaces.Common;
using Caravan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.DataAccess.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        public Task<User?> GetByEmailAsync(string email);
    }
}
