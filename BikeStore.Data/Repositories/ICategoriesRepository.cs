using BikeStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Data.Repositories
{
    public interface ICategoriesRepository
    {
        IEnumerable<Categories> GetAllCategories();

        Categories FinById(int Id);
        Categories AddNewCategory(Categories categories);
        bool DeleteCategory(int Id);

    }
}
