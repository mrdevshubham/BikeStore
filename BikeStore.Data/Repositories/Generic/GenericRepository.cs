using BikeStore.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
                _bikeStoresContext.Remove(entity);

            }
            catch (Exception)
            {
                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return _entity.ToList();
        }

        public T GetById(int Id)
        {
            return _entity.Find(Id);
        }
    }
}
