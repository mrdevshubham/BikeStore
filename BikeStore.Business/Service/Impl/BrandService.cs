using BikeStore.Data.Models;
using BikeStore.Data.Repositories.UnitOfWork;
using BikeStore.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Business.Service.Impl
{
    public class BrandService : IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BrandService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public IEnumerable<Brands> GetAll()
        {
            return _unitOfWork.BrandRepository.GetAll();
        }

        public Brands GetById(int Id)
        {
            return _unitOfWork.BrandRepository.GetById(Id);
        }

        public Brands Add(Brands brand)
        {
            if (_unitOfWork.BrandRepository.GetByName(brand.BrandName) == null)
            {
                _unitOfWork.BrandRepository.Add(brand);
                var Result = _unitOfWork.Complete();

                if (Result == 1)
                    return brand;
            }
            return null;
        }

        public bool Delete(int Id)
        {
            _unitOfWork.BrandRepository.Delete(Id);
            int Result = _unitOfWork.Complete();

            if (Result == 1)
                return true;
            return false;
        }

    }
}
