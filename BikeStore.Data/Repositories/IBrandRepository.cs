using BikeStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Data.Repositories
{
    public interface IBrandRepository
    {
        IEnumerable<Brands> GetAllBrands();

        Brands FinById(int Id);
        Brands AddNewBrand(Brands brand);
        bool DeleteBrand(int Id);
    }
}
