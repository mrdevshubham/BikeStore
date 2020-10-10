using System;
using System.Collections.Generic;
using System.Text;
using BikeStore.Data.Models;
using BikeStore.Data.Repositories.UnitOfWork;
using BikeStore.Model.Request;

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

        public IEnumerable<Products> GetAll()
        {
            return _unitOfWork.ProductsRepository.GetAll();
        }

        public Products GetById(int Id)
        {
            return _unitOfWork.ProductsRepository.GetById(Id);
        }
    }
}
