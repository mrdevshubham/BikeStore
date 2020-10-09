using BikeStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Data.Repositories
{
    public interface ICustomerRepository
    {
        IEnumerable<Customers> GetAll();
        Customers FinById(int Id);
        Customers Add(Customers customers);
        bool Delete(int Id);
    }
}
