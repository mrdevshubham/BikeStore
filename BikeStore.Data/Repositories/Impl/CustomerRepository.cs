using System;
using System.Collections.Generic;
using System.Text;
using BikeStore.Data.Models;
using BikeStore.Data.Repositories.Generic;

namespace BikeStore.Data.Repositories.Impl
{
    public class CustomerRepository : GenericRepository<Customers>, ICustomerRepository
    {
        private BikeStoresContext _dbContext;
        public CustomerRepository(BikeStoresContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
