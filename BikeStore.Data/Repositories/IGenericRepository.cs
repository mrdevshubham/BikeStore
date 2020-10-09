using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Data.Repositories
{
    public interface IGenericRepository<T> where T : DbSet<T>
    {
        IEnumerable<T> GetAll();

        IEnumerable<T> GetById(int Id);


    }
}
