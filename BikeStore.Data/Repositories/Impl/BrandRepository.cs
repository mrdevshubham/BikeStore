using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikeStore.Data.Models;

namespace BikeStore.Data.Repositories.Impl
{
    public class BrandRepository : IBrandRepository
    {
        private BikeStoresContext _dbContext;
        public BrandRepository(BikeStoresContext dbContext)
        {
            _dbContext = dbContext;
        }

        IEnumerable<Brands> IBrandRepository.GetAll()
        {
            List<Brands> Items = _dbContext.Brands.ToList();
            return Items;
        }

        public Brands FinById(int Id)
        {
            return _dbContext.Brands.Where(c => c.BrandId == Id).FirstOrDefault();
        }

        public Brands Add(Brands brand)
        {
            _dbContext.Set<Brands>().Add(brand);
            _dbContext.SaveChanges();

            return brand;
        }

        public bool Delete(int Id)
        {
            try
            {
                var Brand = _dbContext.Brands.Where(c => c.BrandId == Id).FirstOrDefault();
                _dbContext.Remove(Brand);
                _dbContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }

        

        
    }
}
