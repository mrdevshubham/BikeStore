using BikeStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BikeStore.Data.Repositories.Generic
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAll();
        IEnumerable<T> GetAll(int currentPage, int TotalRecorsPerPage);

        T GetById(int Id);
        void Add(T brand);
        void Delete(int Id);


    }
}
