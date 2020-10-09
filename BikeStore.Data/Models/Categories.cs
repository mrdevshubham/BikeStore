using System;
using System.Collections.Generic;

namespace BikeStore.Data.Models
{
    public partial class Categories : BaseEntity
    {
        public Categories()
        {
            Products = new HashSet<Products>();
        }

        public string CategoryName { get; set; }

        public virtual ICollection<Products> Products { get; set; }
    }
}
