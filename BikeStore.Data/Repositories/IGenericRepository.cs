using BikeStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BikeStore.Data.Repositories
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        T Add(T brand);
        bool Delete(int Id);


    }
}
