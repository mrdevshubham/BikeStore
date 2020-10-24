using System;
using System.Collections.Generic;
using System.Text;
using BikeStore.Data.Models;
using BikeStore.Data.Repositories.UnitOfWork;
using BikeStore.Model.Request;

namespace BikeStore.Business.Service.Impl
{
    public class StoreService : IStoreService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StoreService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public Stores Add(Stores store)
        {
            _unitOfWork.StoreRepository.Add(store);
            var Result = _unitOfWork.Complete();

            if (Result == 1)
                return store;
            return null;
        }

        public bool Delete(int Id)
        {
            _unitOfWork.StoreRepository.Delete(Id);
            int Result = _unitOfWork.Complete();

            if (Result == 1)
                return true;
            return false;
        }

        //public IEnumerable<Stores> GetAll()
        //{
        //    return _unitOfWork.StoreRepository.GetAll();
        //}

        public Stores GetById(int Id)
        {
            return _unitOfWork.StoreRepository.GetById(Id);
        }
    }
}
