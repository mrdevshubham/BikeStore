using BikeStore.Data.Models;
using BikeStore.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Business.Service
{
    public interface ICategoryService
    {
        IEnumerable<Categories> GetAll();
        Categories GetById(int Id);
        Categories Add(Categories category);
        bool Delete(int Id);
    }
}
