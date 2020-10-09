using System;
using System.Collections.Generic;
using System.Text;
using BikeStore.Data.Models;

namespace BikeStore.Data.Repositories.Impl
{
    public class OrderRepository : GenericRepository<Orders>, IOrderRepository
    {
        private BikeStoresContext _dbContext;
        public OrderRepository(BikeStoresContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
