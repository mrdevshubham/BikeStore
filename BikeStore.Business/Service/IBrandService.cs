using BikeStore.Data.Models;
using BikeStore.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Business.Service
{
    public interface IBrandService
    {
        IEnumerable<Brands> GetAll();
        Brands GetById(int Id);
        Brands Add(BrandRequestModel brandRequestModel);
        bool Delete(int Id);
    }
}
