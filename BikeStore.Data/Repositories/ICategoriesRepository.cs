using BikeStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Data.Repositories
{
    public interface ICategoriesRepository
    {
        IEnumerable<Categories> GetAll();
        Categories FinById(int Id);
        Categories Add(Categories categories);
        bool Delete(int Id);

    }
}
