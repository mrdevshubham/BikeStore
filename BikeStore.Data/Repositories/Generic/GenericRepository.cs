using BikeStore.Data.Expressions;
using BikeStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikeStore.Data.Repositories.Generic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
    {
        private BikeStoresContext _bikeStoresContext;
        private DbSet<T> _entity;

        public GenericRepository(BikeStoresContext bikeStoresContext)
        {
            _bikeStoresContext = bikeStoresContext;
            _entity = _bikeStoresContext.Set<T>();
        }

        public void Add(T entity)
        {
            _entity.Add(entity);
        }

        public void Delete(int Id)
        {
            try
            {
                var entity = _entity.Where(c => c.Id == Id).FirstOrDefault();

                if (entity != null)
                    _bikeStoresContext.Remove(entity);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entity.ToListAsync();
        }

        public IEnumerable<T> GetAll(int currentPage, int TotalRecorsPerPage)
        {
            return _entity
                    .Skip(currentPage * TotalRecorsPerPage)
                    .Take(TotalRecorsPerPage)
                    .ToList();
        }

        public T GetById(int Id)
        {
            return _entity.Find(Id);
        }

        private IQueryable<T> ApplySpecifications(IQueryable<T> entity, ExpressionBase<T> exp)
        {
            if (exp.WhereClauses != null)
            {
                entity.Where(exp.WhereClauses);
            }

            return entity;
        }
    }
}
