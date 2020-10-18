using BikeStore.Data.Models;
using BikeStore.Data.Repositories.Generic;
using BikeStore.Model.Filters;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BikeStore.Data.Repositories.Impl
{
    public class ProductsRepository : GenericRepository<Products>, IProductsRepository
    {
        private BikeStoresContext _context;
        public ProductsRepository(BikeStoresContext bikeStoreDbContext) : base(bikeStoreDbContext)
        {
            _context = bikeStoreDbContext;
        }

        public IEnumerable<Products> GetProductsFiltered(ProductsFilter productsFilter)
        {
            IQueryable<Products> query = _context.Products;

            if (!string.IsNullOrEmpty(productsFilter.productname))
                query = query.Where(x => x.ProductName.Contains(productsFilter.productname));
            if (productsFilter.brandid > 0)
                query = query.Where(x => x.BrandId == productsFilter.brandid);
            if (productsFilter.categoryid > 0)
                query = query.Where(x => x.CategoryId == productsFilter.categoryid);
            if (productsFilter.modelyearfrom > 0)
                query = query.Where(x => x.ModelYear >= productsFilter.modelyearfrom);
            if (productsFilter.modelyearto > 0)
                query = query.Where(x => x.ModelYear <= productsFilter.modelyearto);
            if (productsFilter.pricefrom > 0)
                query = query.Where(x => x.ListPrice >= productsFilter.pricefrom);
            if (productsFilter.priceto > 0)
                query = query.Where(x => x.ListPrice <= productsFilter.priceto);

            query = query
                    .Skip((productsFilter.currentpage - 1) * productsFilter.recordsperpage)
                    .Take(productsFilter.recordsperpage);

            var Result = query.ToList();

            return Result;
        }

        public Products GetProductDetailsById(int Id)
        {
            var product = _context.Products
                .Where(prod => prod.Id == Id)
                .Select(x => new Products
                {
                    Id = x.Id,
                    ProductName = x.ProductName,
                    ModelYear = x.ModelYear,
                    ListPrice = x.ListPrice,
                    Brand = new Brands
                    {
                        BrandName = x.Brand.BrandName
                    },
                    Category = new Categories
                    {
                        CategoryName = x.Category.CategoryName
                    }
                }).FirstOrDefault();

            return product;
        }
    }
}
