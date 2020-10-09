using System;
using System.Collections.Generic;
using System.Text;
using BikeStore.Data.Models;

namespace BikeStore.Data.Repositories.Impl
{
    public class StaffRepository : GenericRepository<Staffs>, IStaffRepository
    {
        private BikeStoresContext _dbContext;
        public StaffRepository(BikeStoresContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
