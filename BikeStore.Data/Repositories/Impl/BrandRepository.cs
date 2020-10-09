using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeStore.Data.Models;

namespace BikeStore.Data.Repositories.Impl
{
    public class BrandRepository : GenericRepository<Brands> ,IBrandRepository
    {
        private BikeStoresContext _dbContext;
        public BrandRepository(BikeStoresContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        
    }
}
