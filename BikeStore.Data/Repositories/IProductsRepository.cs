using BikeStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Data.Repositories
{
    public interface IProductsRepository
    {
        IEnumerable<Products> GetAll();
        Products FinById(int Id);
        Products Add(Products products);
        bool Delete(int Id);
    }
}
