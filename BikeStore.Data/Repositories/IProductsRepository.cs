using BikeStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using BikeStore.Data.Repositories.Generic;
using BikeStore.Model.Filters;

namespace BikeStore.Data.Repositories
{
    public interface IProductsRepository : IGenericRepository<Products>
    {
        IEnumerable<Products> GetProductsFiltered(ProductsFilter productsFilter);
        Products GetProductDetailsById(int Id);
    }
}
