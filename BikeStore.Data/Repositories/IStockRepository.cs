using BikeStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Data.Repositories
{
    public interface IStockRepository
    {
        IEnumerable<Stocks> GetAll();
        Stocks FinById(int Id);
        Stocks Add(Stocks stocks);
        bool Delete(int Id);
    }
}
