using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BikeStore.Model.Request
{
    public class ProductRequestModel
    {
        public string ProductName { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public Int16 ModelYear { get; set; }
        public decimal ListPrice { get; set; }
    }
}
