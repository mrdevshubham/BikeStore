using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeStore.Data.Models;
using BikeStore.Data.Repositories.Generic;

namespace BikeStore.Data.Repositories.Impl
{
    public class BrandRepository : GenericRepository<Brands> ,IBrandRepository
    {
        private BikeStoresContext _dbContext;
        public BrandRepository(BikeStoresContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Brands GetByName(string brandName)
        {
            return _dbContext.Brands.Where(x => x.BrandName == brandName).FirstOrDefault();
        }
    }
}
