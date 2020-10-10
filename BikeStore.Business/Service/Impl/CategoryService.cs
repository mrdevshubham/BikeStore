using BikeStore.Data.Repositories.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Business.Service.Impl
{
    public class CategoryService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
    }
}
