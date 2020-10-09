using BikeStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Data.Repositories
{
    public interface IOrderRepository
    {
        IEnumerable<Orders> GetAll();
        Orders FinById(int Id);
        Orders Add(Orders orders);
        bool Delete(int Id);
    }
}
