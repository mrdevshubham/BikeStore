using BikeStore.Data.Models;
using BikeStore.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Business.Service
{
    public interface IStoreService
    {
        IEnumerable<Stores> GetAll();
        Stores GetById(int Id);
        Stores Add(Stores store);
        bool Delete(int Id);
    }
}
