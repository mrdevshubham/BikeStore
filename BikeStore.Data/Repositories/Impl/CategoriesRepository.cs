using BikeStore.Data.Models;
using BikeStore.Data.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Data.Repositories.Impl
{
    public class CategoriesRepository : GenericRepository<Categories>, ICategoriesRepository
    {
        private BikeStoresContext _dbContext;
        public CategoriesRepository(BikeStoresContext dbContext): base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
