using BikeStore.Data.Models;
using BikeStore.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Business.Service
{
    public interface IProductService
    {
        IEnumerable<Products> GetAll();
        Products GetById(int Id);
        Products Add(Products product);
        bool Delete(int Id);
    }
}
