using BikeStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace BikeStore.Data.Repositories.Impl
{
    public class ProductsRepository : IProductsRepository
    {
        private BikeStoresContext _context;
        public ProductsRepository(BikeStoresContext bikeStoreDbContext)
        {
            _context = bikeStoreDbContext;
        }

        public List<Products> GetAllProducts()
        {
            List<Products> Products = new List<Products>();

            //Products = _context.Products
            //                    .Select(x => new Products
            //                    {
            //                        ProductId = x.ProductId,
            //                        Brand = new Brands
            //                        {
            //                            Products = x.Brand.Products
            //                        }
            //                    }).ToList();

            Products = _context.Products
                .Join(
                        _context.Brands,
                        product => product.BrandId,
                        brand => brand.BrandId,
                        (product, brand) => new Products
                        {

                            ProductId = product.ProductId,
                            Brand = new Brands
                            {
                                //BrandId = brand.BrandId,
                                BrandName = brand.BrandName
                            }

                        }).ToList();


            return Products;

        }
    }
}
