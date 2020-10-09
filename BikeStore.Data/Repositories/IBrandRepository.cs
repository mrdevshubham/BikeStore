using BikeStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Data.Repositories
{
    public interface IBrandRepository
    {
        IEnumerable<Brands> GetAll();
        Brands FinById(int Id);
        Brands Add(Brands brand);
        bool Delete(int Id);
    }
}
