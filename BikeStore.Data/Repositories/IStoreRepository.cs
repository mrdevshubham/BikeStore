using BikeStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Data.Repositories
{
    public interface IStoreRepository
    {
        IEnumerable<Stores> GetAll();
        Stores FinById(int Id);
        Stores Add(Stores stores);
        bool Delete(int Id);
    }
}
