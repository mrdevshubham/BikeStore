using BikeStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using BikeStore.Data.Repositories.Generic;


namespace BikeStore.Data.Repositories
{
    public interface IStockRepository : IGenericRepository<Stocks>
    {
    }
}
