using System;
using System.Collections.Generic;
using System.Text;
using BikeStore.Data.Models;
using BikeStore.Data.Repositories.Generic;

namespace BikeStore.Data.Repositories.Impl
{
    public class StoreRepository : GenericRepository<Stores>, IStoreRepository
    {
        private BikeStoresContext _dbContext;
        public StoreRepository(BikeStoresContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
