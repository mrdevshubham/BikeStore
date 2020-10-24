using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeStore.Data.Models;
using BikeStore.Data.Repositories.UnitOfWork;
using BikeStore.Model.Filters;
using BikeStore.Model.Request;
using BikeStore.Model.Response;

namespace BikeStore.Business.Service.Impl
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Products Add(Products product)
        {
            _unitOfWork.ProductsRepository.Add(product);
            var Result = _unitOfWork.Complete();

            if (Result == 1)
                return product;
            return null;
        }

        public bool Delete(int Id)
        {
            _unitOfWork.ProductsRepository.Delete(Id);
            int Result = _unitOfWork.Complete();

            if (Result == 1)
                return true;
            return false;
        }

        public IEnumerable<Products> GetAll(int Page, int TotalRecordsPerPage)
        {
            return _unitOfWork.ProductsRepository.GetAll(Page, TotalRecordsPerPage);
        }

        public Products GetById(int Id)
        {
            return _unitOfWork.ProductsRepository.GetProductDetailsById(Id);
        }

        public async Task<BaseFilterResponse<Products>> GetProductsFiltered(ProductsFilter productsFilter)
        {
            var totalRecords = await _unitOfWork.ProductsRepository.GetAll();

            BaseFilterResponse<Products> objResponse = new BaseFilterResponse<Products> 
            {
                PageNumber = productsFilter.currentpage,
                PageSize = productsFilter.recordsperpage,
                TotalRecords = totalRecords.Count(),
                data = _unitOfWork.ProductsRepository.GetProductsFiltered(productsFilter)
            };
            
            return objResponse;
        }
    }
}
