using System;
using System.Collections.Generic;

namespace BikeStore.Data.Models
{
    public partial class Brands : BaseEntity
    {
        public Brands()
        {
            Products = new HashSet<Products>();
        }
        public string BrandName { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
