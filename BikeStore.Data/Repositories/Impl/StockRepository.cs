using System;
using System.Collections.Generic;
using System.Text;
using BikeStore.Data.Models;
using BikeStore.Data.Repositories.Generic;

namespace BikeStore.Data.Repositories.Impl
{
    public class StockRepository : GenericRepository<Stocks>, IStockRepository
    {
        private BikeStoresContext _dbContext;
        public StockRepository(BikeStoresContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
