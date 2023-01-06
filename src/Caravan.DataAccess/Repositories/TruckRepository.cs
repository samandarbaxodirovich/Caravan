﻿using Caravan.DataAccess.DbContexts;
using Caravan.DataAccess.Interfaces;
using Caravan.DataAccess.Repositories.Comman;
using Caravan.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caravan.DataAccess.Repositories
{
    public class TruckRepository : GenericRepository<Truck>, 
        ITruckRepository
    {
        public TruckRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}