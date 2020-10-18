using System;
using System.Collections.Generic;
using System.Text;

namespace BikeStore.Model.Filters
{
    public class ProductsFilter : GenericFilter
    {
        public int brandid { get; set; }
        public int categoryid { get; set; }
        public int modelyearfrom { get; set; }
        public int modelyearto { get; set; }
        public int pricefrom { get; set; }
        public int priceto { get; set; }
        public string productname { get; set; }
        
    }
}
