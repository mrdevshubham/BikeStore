using System;
using System.Collections.Generic;

namespace BikeStore.Data.Models
{
    public partial class Stocks : BaseEntity
    {
        public int ProductId { get; set; }
        public int? Quantity { get; set; }

        public virtual Products Product { get; set; }
        public virtual Stores Store { get; set; }
    }
}
