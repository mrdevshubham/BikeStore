using BikeStore.Data.Models;
using BikeStore.Data.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Data.Repositories
{
    public interface IBrandRepository : IGenericRepository<Brands>
    {
        Brands GetByName(string brandName);

        bool UpdateBrand(int Id, string brandName);
    }
}
