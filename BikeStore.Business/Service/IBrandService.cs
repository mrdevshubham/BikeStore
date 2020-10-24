using BikeStore.Data.Models;
using BikeStore.Model.Request;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.Business.Service
{
    public interface IBrandService
    {
        Task<IEnumerable<Brands>> GetAll();
        Brands GetById(int Id);
        Brands Add(Brands brand);
        bool Delete(int Id);

        bool Update(Brands brand);
    }
}
