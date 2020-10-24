using BikeStore.Data.Models;
using BikeStore.Model.Filters;
using BikeStore.Model.Request;
using BikeStore.Model.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.Business.Service
{
    public interface IProductService
    {
        IEnumerable<Products> GetAll(int Page, int TotalRecordsPerPage);
        Task<BaseFilterResponse<Products>> GetProductsFiltered(ProductsFilter productsFilter);
        Products GetById(int Id);
        Products Add(Products product);
        bool Delete(int Id);
    }
}
