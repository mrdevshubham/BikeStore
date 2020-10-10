using BikeStore.Data.Models;
using BikeStore.Data.Repositories.UnitOfWork;
using BikeStore.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Business.Service.Impl
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Categories Add(Categories category)
        {
            _unitOfWork.CategoriesRepository.Add(category);
            var Result = _unitOfWork.Complete();

            if (Result == 1)
                return category;
            return null;
        }

        public bool Delete(int Id)
        {
            _unitOfWork.CategoriesRepository.Delete(Id);
            int Result = _unitOfWork.Complete();

            if (Result == 1)
                return true;
            return false;
        }

        public IEnumerable<Categories> GetAll()
        {
            return _unitOfWork.CategoriesRepository.GetAll();
        }

        public Categories GetById(int Id)
        {
            return _unitOfWork.CategoriesRepository.GetById(Id);
        }
    }
}
