using BikeStore.Data.Models;
using BikeStore.Data.Repositories.Generic;
using BikeStore.Data.Repositories.Impl;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Data.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public BikeStoresContext _bikeStoresContext;
        public IBrandRepository BrandRepository { get; }
        public ICategoriesRepository CategoriesRepository { get; }
        public ICustomerRepository CustomerRepository { get; }
        public IOrderRepository OrderRepository { get; }
        public IProductsRepository ProductsRepository { get; }
        public IStaffRepository StaffRepository { get; }
        public IStockRepository StockRepository { get; }
        public IStoreRepository StoreRepository { get; }

        public UnitOfWork(BikeStoresContext bikeStoresContext)
        {
            this._bikeStoresContext = bikeStoresContext;
            this.BrandRepository = new BrandRepository(bikeStoresContext);
            this.CategoriesRepository = new CategoriesRepository(bikeStoresContext);
            this.CustomerRepository = new CustomerRepository(bikeStoresContext);
            this.OrderRepository = new OrderRepository(bikeStoresContext);
            this.ProductsRepository = new ProductsRepository(bikeStoresContext);
            this.StaffRepository = new StaffRepository(bikeStoresContext);
            this.StockRepository = new StockRepository(bikeStoresContext);
            this.StoreRepository = new StoreRepository(bikeStoresContext);
        }
        

        public int Complete()
        {
            return _bikeStoresContext.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _bikeStoresContext.Dispose();
            }
        }
    }
}
