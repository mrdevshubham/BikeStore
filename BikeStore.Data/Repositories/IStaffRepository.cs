using BikeStore.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Data.Repositories
{
    public interface IStaffRepository
    {
        IEnumerable<Staffs> GetAll();
        Staffs FinById(int Id);
        Staffs Add(Staffs staffs);
        bool Delete(int Id);
    }
}
