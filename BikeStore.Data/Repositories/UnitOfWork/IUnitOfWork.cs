using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Data.Repositories.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IBrandRepository BrandRepository { get; }
        ICategoriesRepository CategoriesRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        IOrderRepository OrderRepository { get; }
        IProductsRepository ProductsRepository { get; }
        IStaffRepository StaffRepository { get; }
        IStockRepository StockRepository { get; }
        IStoreRepository StoreRepository { get; }

        int Complete();

    }
}
